using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Week_07_LINQ;
[TestClass]
public class CheckingDelegatesForNull
{
    [TestMethod]
    public void Null_Delegate_Checking()
    {
        bool isInvoked = false;
        Action action = new Action(() =>isInvoked = true);
        action();
        Assert.IsTrue(isInvoked);
    }

    [TestMethod]
    public void Action_Delegate_CheckingInlineFunction()
    {
        bool isInvoked = false;
        void SetInvoked()
        {
            isInvoked = true;
        }

        Action action = new Action(SetInvoked);
        //action();
        SetInvoked();
        Assert.IsTrue(isInvoked);
    }

    public Action? Action { get; set; } = null;
    
    [TestMethod]
    public void Null_Delegate_CheckingInlineFunction()
    {
        bool isInvoked = false;
        Action = () => { isInvoked = true; };
        
        Action?.Invoke();

        // /Equivalent
        //Action? temp = Action;
        //if (temp != null)
        //{
        //    temp.Invoke();
        //}

        Assert.IsTrue(isInvoked);
    }
}