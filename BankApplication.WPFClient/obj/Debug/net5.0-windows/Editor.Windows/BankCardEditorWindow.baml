   M S B A M L   `   `   `  ����T  PBankApplication.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:BankApplication.WPFClient.VMsBankApplication.WPFClient.VMs  5   	   4    .BankApplication.WPFClient.BankCardEditorWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:BankApplication.WPFClient.VMs     5   	     � Title$  Bank Card Database��5   	   $	��550��6$   $	��800��61    � DataContext 5	      5   /BankApplication.WPFClient.VMs.BankCardViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $	��10* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��6   
������$��23(�5      $��Corbel)�5      $��Manage Bank Card Database��5      $
��Bold"�5      $��Center=�5      $��Center=�5      �� 5   
   $��2��6   
������6   � 5   
   -   5         �Name$ teszt��5      $��1��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5       �� $��1��6   $��0��6#   ��63   �� *BankCardCollection+ �� SelectedItem 6^   �� *SelectedBankCard+��5!      �� 5"      .R�5#      �� ��6    �� *
CardNumber+5$      5&      �� 5(      $��1��6   .+�5)      �� $��Card Number:��6   
�������$
��Bold"�6E   �� 5*      $��5q�6G   ��6   �� *SelectedBankCard.CardNumber+6G   �� 5,      $��Type of Card:��6   
�������$
��Bold"�6F   �� 5-      $��5q�6   $ �� IsSynchronizedWithCurrentItem$
 TrueY�50      ��5.      ��  �� Path$ 	CardTypes� 5/      �� $ SelectedBankCard.Type�50      �� 52      $��Card CVC Code:��6   
�������$
��Bold"�6G   �� 53      $��5q�6D   ��6   �� *SelectedBankCard.CVCCode+6D   �� 55      $��Create New Bank Card��6   $��5q�6b   $��5,25,5,5q�6n   ��68   �� *CreateBankCardCommand+6n   �� 56      $��Delete Selected Bank Card��6   $��5q�6g   $��5q�6s   ��6=   �� *RemoveBankCardCommand+6s   �� 57      $��Update Selected Bank Card��6   $��5q�6g   $��5,5,5,25q�6s   ��6=   �� *UpdateBankCardCommand+6s   �� 58      -   5        $��Back To Main Menu��58      $��5q�6J   $��5q�6V   59      5:      5;      5<      