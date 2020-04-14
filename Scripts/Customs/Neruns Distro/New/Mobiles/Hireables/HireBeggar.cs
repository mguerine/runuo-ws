using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles 
{
	public class HireBeggar : BaseHire 
	{
		[Constructable] 
		public HireBeggar()
		{
			SpeechHue = Utility.RandomDyedHue();
			Hue = Utility.RandomSkinHue();

			if ( this.Female = Utility.RandomBool() ) 
			{
				Body = 0x191;
				Name = NameList.RandomName( "female" );

			switch ( Utility.Random ( 2 ) )
			{
				case 0: AddItem( new Skirt ( Utility.RandomNeutralHue() ) );break;
				case 1: AddItem( new Kilt ( Utility.RandomNeutralHue() ) );break;
			}
			}
			else 
			{
				Body = 0x190;
				Name = NameList.RandomName( "male" );
				AddItem( new ShortPants( Utility.RandomNeutralHue() ) );
			}
			Title = "the beggar";
			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			hair.Hue = Utility.RandomNeutralHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );

			if( Utility.RandomBool() && !this.Female )
			{
				Item beard = new Item( Utility.RandomList( 0x203E, 0x203F, 0x2040, 0x2041, 0x204B, 0x204C, 0x204D ) );

				beard.Hue = hair.Hue;
				beard.Layer = Layer.FacialHair;
				beard.Movable = false;

				AddItem( beard );
			}

			SetStr( 26, 26 );
			SetDex( 21, 21 );
			SetInt( 36, 36 );

			SetDamage( 1, 1 );

			SetSkill( SkillName.Begging, 66, 97 );
			SetSkill( SkillName.Tactics, 5, 27 );
			SetSkill( SkillName.Wrestling, 5, 27 );
			SetSkill( SkillName.Magery, 2, 2 );		

			Fame = 0;
			Karma = 0;

			AddItem( new Sandals( Utility.RandomNeutralHue() ) );

			switch ( Utility.Random( 2 ) )
			{
				case 0: AddItem( new Doublet( Utility.RandomNeutralHue() ) );break;
				case 1: AddItem( new Shirt( Utility.RandomNeutralHue() ) );break;
			}
		
			PackGold( 0, 25 );
		}
		public override bool ClickTitle{get{return false;}}
		public HireBeggar( Serial serial ) : base( serial ) 
		{
		}

		public override void Serialize( GenericWriter writer ) 
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );// version 
		}

		public override void Deserialize( GenericReader reader ) 
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
