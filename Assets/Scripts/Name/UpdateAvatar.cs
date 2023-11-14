using System;
using Normal.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Name
{
    public class UpdateAvatar : MonoBehaviour
    {
        private RealtimeAvatarManager _realtimeAvatarManager;
        private RealtimeAvatar _realtimeAvatar;
        private string _localPlayerName;

        private void Awake() => _realtimeAvatarManager = GetComponent<RealtimeAvatarManager>();

        private void OnEnable() => _realtimeAvatarManager.avatarCreated += AvatarCreated;

        private void AvatarCreated(RealtimeAvatarManager avatarmanager, RealtimeAvatar avatar, bool islocalavatar)
        {
            if (islocalavatar)
            {
                _realtimeAvatar = avatar;
            }
        }

        public void SaveLocalPlayerName(Text nameField)
        {
            _localPlayerName = nameField.text;
            _realtimeAvatar.GetComponentInChildren<NameSync>().SetText(_localPlayerName);
            nameField.text = "";
        }
    }
}
