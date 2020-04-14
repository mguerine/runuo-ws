//GM Arthanys - Mystara Shard: www.mystara.com.br

using System;
using Server;
using Server.Mobiles;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Accounting;
using Server.Misc;

namespace Server.Gumps
{
	public class PotionGump : Gump
	{
		


		public PotionGump( ) : base(300,30 )
		{



			AddPage( 0 );

			AddBackground( 0, 0, 230, 505, 5054 );
			AddBackground( 10, 10, 210, 485, 3000 );
			//AddImage(100, 200, 30);
			
			AddLabel( 50, 20, 1288, "Potions Gump" );
			
			AddButton( 30, 55, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddLabel( 62, 55, 0x34, "10 Greater Heal" );

			AddButton( 30, 85, 4005, 4007, 2, GumpButtonType.Reply, 0 );
			AddLabel( 62, 85, 0x34, "10 Greater Cure" );

			AddButton( 30, 115, 4005, 4007, 3, GumpButtonType.Reply, 0 );
			AddLabel( 62, 115, 0x34, "10 Total Refresh" );

			AddButton( 30, 145, 4005, 4007, 4, GumpButtonType.Reply, 0 );
			AddLabel( 62, 145, 0x34, "10 Greater Agility" );

			AddButton( 30, 175, 4005, 4007, 5, GumpButtonType.Reply, 0 );
			AddLabel( 62, 175, 0x34, "10 Greater Strength" );

			AddButton( 30, 205, 4005, 4007, 6, GumpButtonType.Reply, 0 );
			AddLabel( 62, 205, 0x34, "10 Greater Explosion" );

			AddButton( 30, 235, 4005, 4007, 7, GumpButtonType.Reply, 0 );
			AddLabel( 62, 235, 0x34, "10 Deadly Poison" );

			AddButton( 30, 265, 4005, 4007, 8, GumpButtonType.Reply, 0 );
			AddLabel( 62, 265, 0x34, "10 Greater Poison" );

			AddButton( 30, 295, 4005, 4007, 9, GumpButtonType.Reply, 0 );
			AddLabel( 62, 295, 0x34, "10 Gtr Conflagration" );

			AddButton( 30, 325, 4005, 4007, 10, GumpButtonType.Reply, 0 );
			AddLabel( 62, 325, 0x34, "10 Gtr Confusion " );

			AddButton( 30, 355, 4005, 4007, 11, GumpButtonType.Reply, 0 );
			AddLabel( 62, 355, 0x34, "2 Mask of Death" );

			AddButton( 30, 385, 4005, 4007, 12, GumpButtonType.Reply, 0 );
			AddLabel( 62, 385, 0x34, "50 Bootles" );
			
			AddButton( 30, 415, 4005, 4007, 13, GumpButtonType.Reply, 0 );
			AddLabel( 62, 415, 0x34, "10 Orange Petals" );

			AddButton( 30, 445, 4006, 4007, 14, GumpButtonType.Reply, 0 );
			AddLabel( 62, 445, 1569, "Open your bank" );

			AddButton( 88, 475, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 122, 477, 75, 20, 1011012, false, false ); // CANCEL


		
		}

 	public override void OnResponse(NetState sender, RelayInfo info)
	{
		Mobile m = sender.Mobile;

		//if (m == null)
		//return;

			switch( info.ButtonID ){
				case 0: 
					m.CloseGump( typeof( PotionGump ) );
					return;

				
				case 1:
					for(int i=0;i<10;i++)
						m.AddToBackpack( new GreaterHealPotion () );
					m.SendMessage("You received: 10 Greater Heal");
					
					break;
				case 2:
					for(int i=0;i<10;i++)
						m.AddToBackpack( new GreaterCurePotion () );
					m.SendMessage("You received: 10 Greater Cure");
					
					break;

				case 3:

					for(int i=0;i<10;i++)
						m.AddToBackpack( new TotalRefreshPotion () );
					m.SendMessage("You received: 10 Total Refresh");
					
					break;
				case 4:
					
					for(int i=0;i<10;i++)
						m.AddToBackpack( new GreaterAgilityPotion () );
					m.SendMessage("You received: 10 Greater Agility");
					
					break;

				case 5:
					
					for(int i=0;i<10;i++)
						m.AddToBackpack( new GreaterStrengthPotion () );
					m.SendMessage("You received: 10 Greater Strength");
					
					break;

				case 6:
					
					for(int i=0;i<10;i++)
						m.AddToBackpack( new GreaterExplosionPotion () );
					m.SendMessage("You received: 10 Greater Explosion");
					
					break;

				case 7:
					
					for(int i=0;i<10;i++)
						m.AddToBackpack( new DeadlyPoisonPotion () );
					m.SendMessage("You received: 10 Deadly Poison");
					
					break;

				case 8:
					
					for(int i=0;i<10;i++)
						m.AddToBackpack( new GreaterPoisonPotion () );
					m.SendMessage("You received: 10 Greater Poison");
					
					break;

				case 9:
					
					for(int i=0;i<10;i++)
					m.AddToBackpack( new GreaterConflagrationPotion () );
					m.SendMessage("You received: 10 Greater Conflagration");
					
					break;

				case 10:
					
					//for(int i=0;i<5;i++)
						//m.AddToBackpack( new GreaterConfusionBlastPotion () );
					m.SendMessage("Sorry! Item unavailable.");
					
					break;

				case 11:
					
					//for(int i=0;i<=1;i++)
						//m.AddToBackpack( new GreaterMaskOfDeathPotion () );
					m.SendMessage("Sorry! Item unavailable.");
					
					break;

				case 12:
					
					m.AddToBackpack( new Bottle(50) );
					m.SendMessage("You received: 50 Bottles");
					
					break;

				case 13:
					
					for(int i=0;i<10;i++)
						m.AddToBackpack( new OrangePetals () );
					m.SendMessage("You received: 10 Orange Petals");
					
					break;


				case 14:
					m.BankBox.Open();
					m.SendMessage("Your bank is open");

					break;

			}
			m.SendGump (new PotionGump());

	}
			

		


	}
}