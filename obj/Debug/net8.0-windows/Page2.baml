   M S B A M L   `   `   `  ����J  FPasswordManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PasswordManegerPasswordManeger  5          PasswordManeger.Page2   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:PasswordManeger     5        N� 
Background
  ����  N� Title$ Page2��5
      .��5      � ���#0f1f2c$	��500��5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��133* �6   �� 5      $
��317* �6   .+�5   
   � $��0��6   $��3��6   .+�5      �� $��32��6   $	��Top=�6!   
���   �$��0 0 0 1q�5   )    �� CornerRadius$ 8 8 0 0��5      ._�5      � .+�5      �� $
��ALMA��6    ���#911e42$��20(�5       $��Center=�5       $��Center=�5        $��Segoe UI Black)�5!       �� 5"      -   5        $��28��5"      $��28��6(   $��Right=�64   
������ ��5$      �� 5%       �� ImageSource$ /Sources/off.png��6)   5'      5(      5)      5*      �� 5+   
   -   5        $��0��5+      $��My passwords��5,      ���#05141a
���   ����#911e42$��55��50      $��10 0 0 0q�6    � 	Resources 51       �� 
TargetType �� Property	 �� Value��%^   '��       �� 52      " ��6   .�53      ��  �@��CornerRadius$	 5��65   54      55      56      �� 57   
   -   5        $��1��57      $��Upload password��58      ���#05141a
���   ����#911e42$��55��5<      $��0 0 0 0q�6    5=      ��%^   '��       �� 5>      " ��6   .�5?      ��  �@��CornerRadius$	 0��65   5@      5A      5B      �� 5C   
   -   5        $��2��5C      $��New password��5D      ���#05141a
���   ����#911e42$��55��5I      $��0 0 10 0q�6    5J      ��%^   '��       �� 5K      " ��6   .�5L      ��  �@��CornerRadius$	 5��65   5M      5N      5O      �� 5P   
   $��0��6   $��3��6!   
���   �$��1q�5Q   %   $
��0 30q�6:   $��1��5R      $��Bottom=�6   &   System.Windows.Controls.DataGrid  5S   
   -   5        
  Name$
 	dataGrid1��5S      $��2��6&   $��3��63   $��10q�6G   ���#3e5159
�������   AutoGenerateColumns$ False��6{      Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$	 URL��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Url+  5V      $ Username��6%    67   �� *
Username+  5W      $ Password��6%    67   �� *
Password+  5X      $ Comment��6%    66   �� *	Comment+  5Y      $
 Tags��6%    63   �� *Tags+5[      5\      5]      