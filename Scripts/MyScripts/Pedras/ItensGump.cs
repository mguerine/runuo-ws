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
	public class ItensGump : Gump
	{
		


		public ItensGump( ) : base(300,15 )
		{



			AddPage( 0 );

			AddBackground( 0, 0, 200, 505, 5054 );
			AddBackground( 10, 10, 180, 485, 3000 );
			//AddImage(100, 200, 30);
			
			AddLabel( 50, 20, 1288, "Itens Gump" );
			
			AddButton( 30, 55, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddLabel( 62, 55, 0x34, "200 Bandages" );

			AddButton( 30, 85, 4005, 4007, 2, GumpButtonType.Reply, 0 );
			AddLabel( 62, 85, 0x34, "200 Arrows" );

			AddButton( 30, 115, 4005, 4007, 3, GumpButtonType.Reply, 0 );
			AddLabel( 62, 115, 0x34, "200 Bolts" );

			AddButton( 30, 145, 4005, 4007, 4, GumpButtonType.Reply, 0 );
			AddLabel( 62, 145, 0x34, "Necro Reagents" );

			AddButton( 30, 175, 4005, 4007, 5, GumpButtonType.Reply, 0 );
			AddLabel( 62, 175, 0x34, "Mage Reagents" );

			AddButton( 30, 205, 4005, 4007, 6, GumpButtonType.Reply, 0 );
			AddLabel( 62, 205, 0x34, "5 Smoke Bombs" );

			AddButton( 30, 235, 4005, 4007, 7, GumpButtonType.Reply, 0 );
			AddLabel( 62, 235, 0x34, "Robe e Cloak" );

			AddButton( 30, 265, 4005, 4007, 8, GumpButtonType.Reply, 0 );
			AddLabel( 62, 265, 0x34, "Alchemy Kit" );

			AddButton( 30, 295, 4005, 4007, 9, GumpButtonType.Reply, 0 );
			AddLabel( 62, 295, 0x34, "Ingot/BS Kit" );

			AddButton( 30, 325, 4005, 4007, 10, GumpButtonType.Reply, 0 );
			AddLabel( 62, 325, 0x34, "Scribe Kit" );

			AddButton( 30, 355, 4005, 4007, 11, GumpButtonType.Reply, 0 );
			AddLabel( 62, 355, 0x34, "Tailor Kit" );

			AddButton( 30, 385, 4005, 4007, 12, GumpButtonType.Reply, 0 );
			AddLabel( 62, 385, 0x34, "Powder-Durability" );

			AddButton( 30, 415, 4005, 4007, 13, GumpButtonType.Reply, 0 );
			AddLabel( 62, 415, 0x34, "Runic Tools" );

			AddButton( 30, 445, 4006, 4007, 14, GumpButtonType.Reply, 0 );
			AddLabel( 62, 445, 1569, "Open up your bank." );

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
					m.CloseGump( typeof( ItensGump ) );
					return;

				
				case 1:
					m.AddToBackpack( new Bandage (200) );
					m.SendMessage("You received: 200 Bandages");
					
					break;
				case 2:
					m.AddToBackpack( new Arrow (200) );
					m.SendMessage("You received: 200 Arrows");
					
					break;


				case 3:

					m.AddToBackpack( new Bolt (100) );
					m.SendMessage("You received: 200 Bolts");
					
					break;
				case 4:
					
					m.AddToBackpack( new BagOfNecroReagents (100) );
					m.SendMessage("You received: 100 each necro reagents.");
					
					break;

				case 5:
					
					m.AddToBackpack( new BagOfReagents (100) );
					m.SendMessage("You received: 100 each mage reagents.");
					
					break;

				case 6:
					
					m.AddToBackpack( new SmokeBomb () );
					m.AddToBackpack( new SmokeBomb () );
					m.AddToBackpack( new SmokeBomb () );
					m.AddToBackpack( new SmokeBomb () );
					m.AddToBackpack( new SmokeBomb () );
					m.SendMessage("You received: 5 Smoke Bombs.");
					
					break;

				case 7:
					
					m.AddToBackpack( new Robe () );
					m.AddToBackpack( new Cloak () );
					//m.AddToBackpack( new DeathShroud () );
					m.SendMessage("You received: 1 Robe e 1 Cloack.");
					
					break;

				case 8:
					
					m.AddToBackpack( new AlchemyBag() );
					m.SendMessage("You received: 1 Alchemy Kit.");
					
					break;

				case 9:
					
					//m.AddToBackpack( new BagOfingots( 1000 ) );
					m.AddToBackpack( new SmithBag( 1000 ) );
					m.SendMessage("You received: 1 BS/Ingot Kit.");
					
					break;

				case 10:
					
					m.AddToBackpack( new ScribeBag() );
					m.SendMessage("You received: 1 Scribe Kit.");
					
					break;


				case 11:
					
					m.AddToBackpack( new TailorBag() );
					m.SendMessage("You received: 1 Tailor Kit.");
					
					break;

				case 12:
					
					//for(int i=0;i<5;i++)
						m.AddToBackpack( new PowderOfTemperament() );
					m.SendMessage("You received: 1 Powder.");
					
					break;

				case 13:
					
					m.AddToBackpack( new BagofRunica() );
					m.SendMessage("You received: Runic Tools.");
					
					break;


				case 14:
	

					m.BankBox.Open();
					m.SendMessage("Your bank is now open.");
					break;

			}
			m.SendGump (new ItensGump());
		}
	}
}