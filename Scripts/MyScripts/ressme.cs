// Edited by: Mark Ribeiro

using System;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using System.Collections;
using System.IO;
using Server;
using Server.Gumps;
using Server.Commands;

namespace Server
{
	public class RessMe
	{
	
		public static bool ressa=true; 
   			
		public static void Initialize()
		{
			CommandSystem.Register( "RessMe", AccessLevel.Player, new CommandEventHandler( RessMe_OnCommand ) );
		}
		
		[Usage( "RessMe" )]
		[Description( "Resurrect yourself using this command." )]
		public static void RessMe_OnCommand( CommandEventArgs e )
		{	
			m_Mobile = e.Mobile;
			
			if ( e.Mobile.Hits <= 0 && e.Mobile.Body != 749 ){
				if(ressa == true){
					m_Mobile.SendMessage("Resurrecting...");
					Timer timer = new FlameTimer( m_Mobile );
					timer.Start();
				}
				else
					m_Mobile.SendMessage("You or other player is using this command. Wait a second.");
			}
			else
				m_Mobile.SendMessage("You are not dead!"); 
		
		}
		private static Mobile m_Mobile;
		private static int m_Count;

		private class FlameTimer : Timer
		{
			private Mobile m_Mobile;


			public FlameTimer( Mobile from ) : base( TimeSpan.Zero, TimeSpan.FromSeconds( 5.0 ) )
			{
				ressa = false;
				m_Mobile = from;
				m_Count = 0;
				Priority = TimerPriority.TenMS;
				
			}

			protected override void OnTick()
			{				
				if(m_Count==0){
					m_Mobile.Resurrect();
					m_Mobile.PlaySound( 0x208 );
					m_Mobile.PlaySound( 0x209 );
					m_Mobile.FixedParticles( 0x376A, 9, 32, 5030, EffectLayer.Waist );
					m_Mobile.SendMessage("You're alive.");
					m_Mobile.Blessed=true; // Edited
					m_Mobile.SendMessage("You have 20 seconds to re-equip.");
					m_Mobile.Hits = m_Mobile.HitsMax;
					m_Mobile.Mana = m_Mobile.ManaMax;
					m_Mobile.Stam = m_Mobile.StamMax;
				}
				if(m_Count==4){
					m_Mobile.SendMessage("You have only 5 seconds immortal remaining.");
				}
				if(m_Count==5){
					ressa=true;
					m_Mobile.SendMessage("You are no longer immortal.");
					m_Mobile.Blessed=false; // Edited
					Stop();
				}

				m_Count++;
			}
		}
    }
}