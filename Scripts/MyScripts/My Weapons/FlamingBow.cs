using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13b2 , 0x13b1 )]
	public class FlamingBow : Bow {
		public override int ArtifactRarity{ get{ return 19; } }		// Edited
		public override float MlSpeed { get { return 3.75f; } }
		public override int DefMaxRange { get { return 11; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }
		
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }


		[Constructable]
		public FlamingBow() : base( 0x13b2 )
		{
            Name = "Flaming Bow";
            Hue = 0x7AD;
			Attributes.AttackChance = 20;
			Attributes.DefendChance = 10;
            Attributes.WeaponDamage = 40;
            Attributes.WeaponSpeed = 30;
			WeaponAttributes.HitLeechMana = 30;
           
		}

        public FlamingBow(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}