   M S B A M L   `   `   `  ����T  PBankApplication.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:BankApplication.WPFClient.VMsBankApplication.WPFClient.VMs  5   	   :    4BankApplication.WPFClient.CurrentAccountEditorWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:BankApplication.WPFClient.VMs     5   	     � Title$  Current Account Database��5   	   $	��550��6*   $	��800��67    � DataContext 5	      ;   5BankApplication.WPFClient.VMs.CurrentAccountViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $	��10* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��6   
������$��23(�5      $��Corbel)�5      $%��Manage Current Account Database��5      $
��Bold"�5      $��Center=�5      $��Center=�5      �� 5   
   $��2��6   
������6   � 5   
   -   5         �Name$ teszt��5      $��1��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5       �� $��1��6   $��0��6#   ��63   �� *CurrentAccountCollection+ �� SelectedItem 6d   �� *SelectedAccount+��5!      �� 5"      .R�5#      ��  �� Orientation$ 
Horizontal=�6%   .+�5$      �� ��6$   �� *AccountNumber+�� 5%       �� ContentStringFormat$ [{0}]��6G   ��6$   �� *AccountBalance+6G   �� 5&      $ [{0}]��6H   ��6$   �� *AccountCurrency+6H   �� 5'      $ [{0}]��6N   ��6$   �� *AccountOwner.CustName+6N   5(      5)      5+      �� 5-      $��1��6   .+�5.      �� $��Account ID:��6   
�������$
��Bold"�6D   �� 5/      $��5q�6I   ��6   �� *SelectedAccount.AccountNumber+6I   �� 51      $��Account Balance:��6   
�������$
��Bold"�6I   �� 52      $��5q�6J   ��6   �� * SelectedAccount.AccountBalance+6J   �� 54      $��Account Currency:��6   
�������$
��Bold"�6J   �� 55      $��5q�6K   ��6   �� *!SelectedAccount.AccountCurrency+6K   �� 57      $ ��Create New Current Account��6   $��5q�6n   $��5,25,5,5q�6z   ��6>   �� *CreateCurrentAccountCommand+6z   �� 58      $%��Delete Selected Current Account��6   $��5q�6s   $��5q�6   ��6C   �� *RemoveCurrentAccountCommand+6   �� 59      $%��Update Selected Current Account��6   $��5q�6s   $��5,5,5,25q�6   ��6C   �� *UpdateCurrentAccountCommand+6   �� 5:      -   5        $��Back To Main Menu��5:      $��5q�6J   $��5q�6V   5;      5<      5=      5>      