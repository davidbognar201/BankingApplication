   M S B A M L   `   `   `  ����T  PBankApplication.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:BankApplication.WPFClient.VMs.NonCrudVMs(BankApplication.WPFClient.VMs.NonCrudVMs  5   	   ]    WBankApplication.WPFClient.Editor.Windows.NonCrud.Windows.GetCustomersByMinBalanceWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:BankApplication.WPFClient.VMs.NonCrudVMs     5   	     � Title$$  GetCustomersByMinBalanceWindow��5   	   $	��450��60   $	��800��6=   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��1.5* �6   �� 5      $	��10* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��6   
������$��23(�5      $��Corbel)�5      $0��*List Customers Above Given Account Balance��5      $
��Bold"�5      $��Center=�5      $��Center=�5      �� 5   
   $��2��6   
������6   � 5   
   $��1��6    5      �� 5      $	��10* �6    �� 5      $��2* �6    .+�5      �� $��0��6   ��6(   �� *CustomerCollection+��5      �� 5      .R�5       ��  �� Orientation$ 
Horizontal=�6%   .+�5!      �� ��6$   �� *
CustName+�� 5"       �� ContentStringFormat$ [{0}]��6D   ��6$   �� *YearOfBirth+6D   �� 5#      $ [{0}]��6@   ��6$   �� *	Country+6@   5$      5%      5'      �� 5)      -   5        $��1��5)      $��Back to Main Menu��6"   $��5q�6>   $��10q�6J   6m   5*      5.      5/      