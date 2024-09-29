using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.Presentation.UserProfile
{
    public class UserProfileLifetimeScope : LifetimeScope
    {
        [SerializeField] private UserProfileView view;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(view).AsImplementedInterfaces();
        }
    }
}