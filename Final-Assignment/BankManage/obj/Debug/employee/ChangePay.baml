   M S B A M L   `   `   `  ����  
BankManage#    BankManage.employee.ChangePay   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  	ChangePay��5      .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .  $	��228��6t   $	��Top=�6�   $��	0,10,26,0q�6�   $��Center=�6�   $	��474��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   ��5      �� 5       �� Color$ 	#FFF0F0F0��6"    �� Opacity$ 0Q�64      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 	员工号��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 70 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *
EmployeeNo+6Q     5      $	 姓名��6%   $
 70 6J    61   �� *Name+6J     5      $	 工作时间��6%   $
 70 6P    63   �� *
WorkTime+6P     5      $	 薪水��6%   $
 70 6L    61   �� *Salary+6L   5      �� 5   
   -   5        $��刷新��5      $
��Left=�6   $��316,284,0,0q�69   $	��Top=�6N   $��75��6f   6q   5      5      