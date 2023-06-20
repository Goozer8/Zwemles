﻿namespace Swim_Feedback.Data
{
    public class AvatarAccessory
    {
        public long AvatarId { get; set; }
        public Avatar? Avatar { get; set; }
        public long AccessoryId { get; set; }
        public Accessory? Accessory { get; set; }

        public AvatarAccessory(long avatarId, long accessoryId)
        {
            AvatarId = avatarId;
            AccessoryId = accessoryId;
        }

        public AvatarAccessory(Avatar avatar, Accessory accessory)
        {
            Avatar = avatar;
            Accessory = accessory;
        }
    }
}
