using Naveasy.Common;

namespace Naveasy.Behaviors;

public class NavigationPageSystemGoBackBehavior : BehaviorBase<NavigationPage>
{
    protected override void OnAttachedTo(NavigationPage bindable)
    {
        bindable.Popped += NavigationPage_Popped;
        base.OnAttachedTo(bindable);
    }

    protected override void OnDetachingFrom(NavigationPage bindable)
    {
        bindable.Popped -= NavigationPage_Popped;
        base.OnDetachingFrom(bindable);
    }

    private void NavigationPage_Popped(object sender, NavigationEventArgs e)
    {
        MvvmHelpers.HandleSystemGoBack(e.Page, AssociatedObject.CurrentPage);
    }
}