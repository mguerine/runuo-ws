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
	public class Stone
	{   	
	
		public static void Initialize()
		{
			CommandSystem.Register( "Stone", AccessLevel.Counselor, new CommandEventHandler( Stone_OnCommand ) );	
		}
		
		[Usage( "Stone" )]
		[Description( "Stone a target." )]
		public static void Stone_OnCommand( CommandEventArgs e )
		{
		
			PlayerMobile from = e.Mobile as PlayerMobile; 
          
			if( from != null ) 
			{  
				from.SendMessage ( "Target a player to Stone" );
				from.Target = new InternalTarget();
			} 

	}



	private class InternalTarget : Target
	{
		public InternalTarget() : base( -1, false, TargetFlags.None )
		{
		}

		protected override void OnTarget( Mobile from, object obj )
		{

			if(obj is Mobile)
			{
				Mobile mob = (Mobile)obj;


				if(mob.AccessLevel > from.AccessLevel){
					from.SendMessage("You are not allowed to do this.");
				}
				else{

						if( (mob.CantWalk == false) || (mob.Frozen == false) ){
							mob.SendMessage("You are Stoned");
							from.SendMessage("Stoned: {0}", mob.Name);
							mob.CantWalk=true;
							mob.Frozen=true;
							mob.Squelched=true;
							mob.SolidHueOverride = 1153;
							mob.Blessed=true;
							//mob.Title="[Stoned]";
			
							
							
						}
						else{
	
							mob.SendMessage("You Feel The Freedom");
							mob.CantWalk=false;
							mob.Frozen=false;
							mob.Squelched=false;
							mob.SolidHueOverride = -1;
							mob.Blessed=false;
							//mob.Title="";
	
	
	
							}
					
					
				}
			}
			else{
						from.SendMessage("Target invalid.");
					}



		}
			
    }
}
}