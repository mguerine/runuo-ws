//GM Arthanys - Mystara Shard: www.mystara.com.br

using System;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Accounting;

using Server.Multis;


namespace Server.Gumps
{
	public class SkinGump : Gump
	{
		


		public SkinGump( ) : base(300,30 )
		{



			AddPage( 0 );

			AddBackground( 0, 0, 200, 505, 5054 );
			AddBackground( 10, 10, 180, 485, 3000 );
			//AddImage(100, 200, 30);
			
			AddLabel( 50, 20, 1288, "Your skin color" );
			
			AddButton( 30, 55, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddLabel( 62, 55, 0x34, "Default" );

			AddButton( 30, 85, 4005, 4007, 2, GumpButtonType.Reply, 0 );
			AddLabel( 62, 85, 0x34, "Black" );

			AddButton( 30, 115, 4005, 4007, 3, GumpButtonType.Reply, 0 );
			AddLabel( 62, 115, 0x34, "Darkness" );

			AddButton( 30, 145, 4005, 4007, 4, GumpButtonType.Reply, 0 );
			AddLabel( 62, 145, 0x34, "White up" );

			AddButton( 30, 175, 4005, 4007, 5, GumpButtonType.Reply, 0 );
			AddLabel( 62, 175, 0x34, "Rose mary" );

			AddButton( 30, 205, 4005, 4007, 6, GumpButtonType.Reply, 0 );
			AddLabel( 62, 205, 0x34, "Blue man" );

			AddButton( 30, 235, 4005, 4007, 7, GumpButtonType.Reply, 0 );
			AddLabel( 62, 235, 0x34, "Orange juice" );

			AddButton( 30, 265, 4005, 4007, 8, GumpButtonType.Reply, 0 );
			AddLabel( 62, 265, 0x34, "Green acres" );

			AddButton( 30, 295, 4005, 4007, 9, GumpButtonType.Reply, 0 );
			AddLabel( 62, 295, 0x34, "Shiny boy" );

			AddButton( 30, 325, 4005, 4007, 10, GumpButtonType.Reply, 0 );
			AddLabel( 62, 325, 0x34, "Iceman" );

			AddButton( 30, 355, 4005, 4007, 11, GumpButtonType.Reply, 0 );
			AddLabel( 62, 355, 0x34, "Metal" );
			
			AddButton( 30, 385, 4005, 4007, 12, GumpButtonType.Reply, 0 );
			AddLabel( 62, 385, 0x34, "A way orange" );

			AddButton( 30, 415, 4005, 4007, 13, GumpButtonType.Reply, 0 );
			AddLabel( 62, 415, 0x34, "Green off" );

			AddButton( 30, 445, 4005, 4007, 14, GumpButtonType.Reply, 0 );
			AddLabel( 62, 445, 0x34, "Blood" );

			AddButton( 88, 475, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 122, 477, 75, 20, 1011012, false, false ); // CANCEL


		
		}

 	public override void OnResponse(NetState sender, RelayInfo info)
	{
		Mobile m = sender.Mobile;

		//if (m == null)
		//return;

			switch( info.ButtonID ){
				case 0: m.CloseGump( typeof( ItensGump ) );
					break;

				
				case 1:
					m.Hue = 33770;
					break;
				case 2:
					m.Hue = 33790;
					break;
				case 3:
					m.Hue = 1;
					break;
				case 4:
					m.Hue = 0;
					break;
				case 5:
					m.Hue = 24;
					break;
				case 6:
					m.Hue = 1261;
					break;
				case 7:
					m.Hue = 1939;
					break;
				case 8:
					m.Hue = 1267;
					break;
				case 9:
					m.Hue = 1559;
					break;
				case 10:
					m.Hue = 1288;
					break;
				case 11:
					m.Hue = 1953;
					break;
				case 12:
					m.Hue = 1101;
					break;
				case 13:
					m.Hue = 1964;
					break;
				case 14:
					m.Hue = 1932;
					break;
			}

			m.SendMessage("Reopen your Paperdoll.");

	}
			

		


	}
}