using System;
using System.Collections;

namespace Server.Items
{
	/// <summary>
	/// This devastating strike is most effective against those who are in good health and whose reserves of mana are low, or vice versa.
	/// </summary>
	public class ConcussionBlow : WeaponAbility
	{
		public ConcussionBlow()
		{
		}

		public override int BaseMana{ get{ return 25; } }

		public static readonly TimeSpan PlayerDuration = TimeSpan.FromSeconds( 6.0 );
		public static readonly TimeSpan NPCDuration = TimeSpan.FromSeconds( 12.0 );
		
		public override bool OnBeforeDamage( Mobile attacker, Mobile defender )
		{
			if ( !Validate( attacker ) || !CheckMana( attacker, true ) )
				return false;

			ClearCurrentAbility( attacker );

			attacker.SendLocalizedMessage( 1060165 ); // You have delivered a concussion!
			defender.SendLocalizedMessage( 1060166 ); // You feel disoriented!

			defender.PlaySound( 0x213 );
			defender.FixedParticles( 0x377A, 1, 32, 9949, 1153, 0, EffectLayer.Head );

			Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( defender.X, defender.Y, defender.Z + 10 ), defender.Map ), new Entity( Serial.Zero, new Point3D( defender.X, defender.Y, defender.Z + 20 ), defender.Map ), 0x36FE, 1, 0, false, false, 1133, 3, 9501, 1, 0, EffectLayer.Waist, 0x100 );

			
			int damage = 10; // Base damage is 10.

			
			/*if ( defender.HitsMax > 0 ) 
			{
				double hitsPercent = ( (double)defender.Hits / (double)defender.HitsMax ) * 100.0;

				double manaPercent = 0;

				if ( defender.ManaMax > 0 )
					manaPercent = ( (double)defender.Mana / (double)defender.ManaMax ) * 100.0;

				damage += Math.Min( (int)(Math.Abs( hitsPercent - manaPercent ) / 4), 20 );
			}*/

			if(!IsConcussioned(defender )){
				BeginConcussion( defender, defender.Player ? PlayerDuration : NPCDuration );
			}
			defender.Damage( damage, attacker );

			return true;
		}
		private static Hashtable m_Table = new Hashtable();
		private static int manaDrained;

		public static bool IsConcussioned( Mobile m )
		{
			return m_Table.Contains( m );
		}

		public static void BeginConcussion( Mobile m, TimeSpan duration )
		{
			Timer t = (Timer)m_Table[m];

			if ( t != null )
				t.Stop();

			t = new InternalTimer( m, duration );
			m_Table[m] = t;
						
			t.Start();
			
			manaDrained = m.Mana/2;
			m.Mana = m.Mana - manaDrained;

		}

		public static void EndConcussion( Mobile m )
		{
			if ( !IsConcussioned( m ) )
				return;

			Timer t = (Timer)m_Table[m];

			if ( t != null )
				t.Stop();

			m_Table.Remove( m );
			m.Mana += manaDrained;
			manaDrained = 0;
			m.SendMessage("You recover from your concussion.");
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;

			public InternalTimer( Mobile m, TimeSpan duration ) : base( duration )
			{
				m_Mobile = m;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				EndConcussion( m_Mobile );
			}
		}
	}
}

