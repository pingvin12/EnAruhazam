using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace EnAruhazam
{
    public class MenuTabLogic
    {
        public Button[] mainParentButtons;
        public Button backButton;
        public Button[] mainChildButtons;
        public StackPanel stackPanel;
        
        /// <summary>
        /// WindowLogic constructor
        /// </summary>
        /// <param name="mainParentButtons">All the main parent buttons.</param>
        /// <param name="backButton">Back button</param>
        /// <param name="mainChildButtons">Children buttons of the parent</param>
        /// <param name="stackPanel">The stackpanel that we will modify.</param>
        public MenuTabLogic(Button[] mainParentButtons, Button backButton, Button[] mainChildButtons, StackPanel stackPanel)
        {
            this.mainParentButtons = mainParentButtons;
            this.backButton = backButton;
            this.mainChildButtons = mainChildButtons;
            this.stackPanel = stackPanel;
          
        }
        /// <summary>
        /// Reverts back to the initial look of the defined stackpanel
        /// </summary>
        public void RevertWindowChild()
        {
          
                foreach (var item in mainParentButtons)
                {
                    item.Visibility = Visibility.Visible;
                }
                backButton.Visibility = Visibility.Hidden;
                foreach (var item in mainChildButtons)
                {
                    item.Visibility = Visibility.Hidden;
                }
                stackPanel.Children.Clear();


           

        }

   
        /// <summary>
        /// Uses a window as a child in the defined stackpanel
        /// </summary>
        /// <param name="Desiredwindow">The window that we want to modify.</param>
        public void ChangeWindowChild(Window Desiredwindow)
        {
         
          
                foreach (var item in mainParentButtons)
                {
                    item.Visibility = Visibility.Hidden;
                }
                backButton.Visibility = Visibility.Visible;

                foreach (var item in mainChildButtons)
                {
                    item.Visibility = Visibility.Hidden;

                }
            

            stackPanel.Children.Clear();
            object content = Desiredwindow.Content;
            Desiredwindow.Content = null;
            Desiredwindow.Close();
            stackPanel.Children.Add(content as UIElement);

        }
        /// <summary>
        /// Creates submenu by setting the content's visibility to hidden
        /// Must have a set of pre initialized content that we can set to visible
        /// </summary>
        public void AddSubmenu()
        {
          
           
                foreach (var item in mainParentButtons)
                {
                    item.Visibility = Visibility.Hidden;
                }
                backButton.Visibility = Visibility.Visible;
                foreach (var item in mainChildButtons)
                {
                    item.Visibility = Visibility.Visible;

                }
                stackPanel.Children.Clear();

          
        }

    }
}
