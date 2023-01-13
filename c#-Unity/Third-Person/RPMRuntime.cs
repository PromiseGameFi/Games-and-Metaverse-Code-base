using UnityEngine;
using UnityEngine.UI;

namespace ReadyPlayerMe
{
    public class RPMRuntime : MonoBehaviour
    {
        [SerializeField]
        private InputField avatarUrlInputField;
        [SerializeField]
        private GameObject avatar;

        public GameObject avatarspot;
        private void Start()
        {
            ApplicationData.Log();
        }

        public void LoadAvatar()
        {
            var avatarUrl = avatarUrlInputField.text;
            var avatarLoader = new AvatarLoader();
            avatarLoader.OnCompleted += (_, args) =>
            {
                avatar = args.Avatar;
                //AvatarAnimatorHelper.SetupAnimator(args.Metadata.BodyType, avatar);
            };
            avatarLoader.LoadAvatar(avatarUrl);
        }

        

        private void OnDestroy()
        {
            if (avatar != null) Destroy(avatar);
        }
    }
}

