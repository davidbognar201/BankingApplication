   M S B A M L   `   `   `  ����T  PBankApplication.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BankApplication.WPFClientBankApplication.WPFClient  5   	   *    $BankApplication.WPFClient.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:BankApplication.WPFClient     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��1.5* �6   �� 5      $	��10* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��6   
������$��23(�5      $��Corbel)�5      $��Banking CRUD Application��5      $
��Bold"�5      $��Center=�5      $��Center=�5      �� 5   
   $��2��6   
������6   � 5   
   -   5         �Name$ teszt��5      $��1��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��2* �6#   �� 5      $��1* �6#   .+�5      �� $��1��6   $��1��6&   $��15q�66   .+�5      �� -   5         ��Name$ 
custButton��5      $��Manage Customer Data��6-   $��10q�6L   $��10q�6Y   6e   �� 5       -   5        $ caButton��5       $!��Manage Current Account Data��6+   $��10q�6Q   $��10q�6^   6j   �� 5!      -   5        $ 
cardButton��5!      $��Manage Bank Card Data��6-   $��10q�6M   $��10q�6Z   6f   �� 5"      -   5        $ noncrudButton��5"      $��Manage Non-Crud Data��60   $��10q�6O   $��10q�6\   6h   �� 5#      -   5        $ 
exitButton��5#      $
��Exit��6-   $��10q�6<   $��10q�6I   6U   5$      5%      5&      5'      