using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace EnAruhazam
{
    public class MainAdminWindowLogic
    {
        public Button[] mainParentButtons;
        public Button backButton;
        public Button[] mainChildButtons;
        public StackPanel stackPanel;
        

        public MainAdminWindowLogic(Button[] mainParentButtons, Button backButton, Button[] mainChildButtons, StackPanel stackPanel)
        {
            this.mainParentButtons = mainParentButtons;
            this.backButton = backButton;
            this.mainChildButtons = mainChildButtons;
            this.stackPanel = stackPanel;
          
        }
        //Reverts back to the initial look of the defined stackpanel
        public void RevertWindowChild(Button[] parentButtons ,Button[] childButtons)
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

        //Uses a window as a child in the defined stackpanel
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
        //Creates submenu by setting the content's visibility to hidden
        //Must have a set of pre initialized content that we can set to visible
        public void AddSubmenu(Button[] parentButtons, Button[] childButtons)
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
