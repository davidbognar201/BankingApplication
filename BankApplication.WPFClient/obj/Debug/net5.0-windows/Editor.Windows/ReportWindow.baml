   M S B A M L   `   `   `  ����T  PBankApplication.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:BankApplication.WPFClient.VMsBankApplication.WPFClient.VMs  5   	   ;    5BankApplication.WPFClient.Editor.Windows.ReportWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:BankApplication.WPFClient.VMs     5   	     � Title$  ReportMainWindow��5   	   $	��550��6"   $	��800��6/    � DataContext 5	      =   7BankApplication.WPFClient.VMs.ReportMainWindowViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5   
   $
��1.5* �6   �� 5   
   $	��10* �6   �� 5   
   $
��1.5* �6   .+�5      �� $��0��6   
������$��23(�5      $��Corbel)�5      $"��Generate pre-defined reports��5      $
��Bold"�5      $��Center=�5      $��Center=�5      �� 5      $��2��6   
������6   � 5      -   5         �Name$ teszt��5      $��1��6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��1* �6   .+�5!   
   �� $��1��6   $��1��6"   $��15q�62   .+�5"      �� -   5         ��Name$ currencyAggButton��5"      $&�� Get Cards Aggregated By Currency��60   $��10q�6[   $��10q�6h   6t   �� 5#      -   5        $ countryAggButton��5#      $)��#Get Customers Aggregated By Country��6/   $��10q�6]   $��10q�6j   6v   �� 5$      -   5        $ minBalanceAggButton��5$      $)��#Get Customers Above Minimum Balance��62   $��10q�6`   $��10q�6m   6y   �� 5%      -   5        $ cardCountryAggButton��5%      $%��Get Cards Aggregated By Country��63   $��10q�6]   $��10q�6j   6v   �� 5&      -   5        $ cardCntAggButton��5&      $.��(Get Customers Based On Their Card Amount��6/   $��10q�6b   $��10q�6o   6{   �� 5'      -   5        $ 
exitButton��5'      $��Back To Main Menu��6)   $��10q�6E   $��10q�6R   6^   5(      5)      5*      5+      