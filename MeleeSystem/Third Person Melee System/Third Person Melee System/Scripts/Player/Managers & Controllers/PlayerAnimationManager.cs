namespace ThirdPersonMeleeSystem.Managers
{
    public class PlayerAnimationManager : AnimationManager
    {
        #region Public Fields
        #endregion
    
        #region Private Fields
        #endregion
    
        #region Serialized Fields
        #endregion
    
        #region Getters
    
        public static PlayerAnimationManager Instance { get; private set; }
    
        #endregion

        protected override void Start()
        {
            base.Start();
            SetupSingleton();
        }

        private void SetupSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
    }
}
