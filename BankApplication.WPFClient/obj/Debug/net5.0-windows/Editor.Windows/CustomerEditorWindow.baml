   M S B A M L   `   `   `  ����T  PBankApplication.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:BankApplication.WPFClient.VMsBankApplication.WPFClient.VMs  5   	   ?    9BankApplication.WPFClient.CardsAggregatedByCuurencyWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:BankApplication.WPFClient.VMs     5   	     � Title$  Customer Database��5   	   $	��558��6#   $	��800��60    � DataContext 5	      5   /BankApplication.WPFClient.VMs.CustomerViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $	��10* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��6   
������$��23(�5      $��Corbel)�5      $��Manage Customer Database��5      $
��Bold"�5      $��Center=�5      $��Center=�5      �� 5   
   $��2��6   
������6   � 5   
   -   5         �Name$ teszt��5      $��1��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5       �� $��1��6   $��0��6#   ��63   �� *CustomerCollection+ �� SelectedItem 6^   �� *SelectedCustomer+��5!      �� 5"      .R�5#      �� ��6    �� *
CustName+5$      5&      �� 5(      $��1��6   .+�5)      �� $��Customer name:��6   
�������$
��Bold"�6G   �� 5*      $��5q�6E   ��6   �� *SelectedCustomer.CustName+6E   �� 5,      $��Year of birth:��6   
�������$
��Bold"�6G   �� 5-      $��5q�6H   ��6   �� *SelectedCustomer.YearOfBirth+6H   �� 5/      $��Average Income:��6   
�������$
��Bold"�6H   �� 50      $��5q�6J   ��6   �� * SelectedCustomer.AverageIncome+6J   �� 52      $��Country:��6   
�������$
��Bold"�6A   �� 53      $��5q�6D   $��0,0,0,15q�6P   ��6   �� *SelectedCustomer.Country+6P   �� 55      $��Create New Customer��6   $��5q�6a   $��5q�6m   ��67   �� *CreateCustomerCommand+6m   �� 56      $��Delete Selected Customer��6   $��5q�6f   $��5q�6r   ��6<   �� *RemoveCustomerCommand+6r   �� 57      $��Update Selected Customer��6   $��5q�6f   $��5,5,5,25q�6r   ��6<   �� *UpdateCustomerCommand+6r   �� 58      -   5        $��Back To Main Menu��58      $��5q�6J   $��5q�6V   59      5:      5;      5<      