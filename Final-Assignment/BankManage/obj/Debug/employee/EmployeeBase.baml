   M S B A M L   `   `   `  ����  
BankManage&     BankManage.employee.EmployeeBase   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  EmployeeBase��5      .��5
      � .+�5   
   �� $
��Left=�6   $	��258��60   $��10,0,0,0q�6=   $	��Top=�6O   $	��542��6g   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5   3      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .  $	��421��6w   $	��Top=�6�   $��	0,0,-90,0q�6�   $
��Left=�6�   $	��632��6�   ��5      �� 5       �� Color$ 	#FFF0F0F0��6&    �� Opacity$ 0Q�68      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 姓名��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 60 6V   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *EmployeeName+6V     5      $ 性别��6)   $	 60 6M   
 65   �� *sex+6M     5      $ 工作时间��6)   $	 80 6T   
 67   �� *
workDate+6T     5      $ 手机号码��6)   $	 80 6T   
 67   �� *
telphone+6T     5      $ 员工证件��6)   $	 80 6R   
 67   �� *idCard+6R     5      $ 照片��6)   $
	 Auto 6O   
 65   �� *photo+6O   5      5      �� 5   
   $
��Left=�6   $��35��60   $��190,171,0,0q�6<   $	��Top=�6Q   $	��133��6i   .+�5      �� -   5        $��增加��5      $��24��6"   $��-100,5,133.667,0q�6.   6H   5      �� 5   
   $
��Left=�6   $��49��60   $��280,157,0,0q�6<   $	��Top=�6Q   $	��146��6i   .+�5      �� -   5        $��删除��5      $��24��6"   $��
10,20,28,0q�6.   6B   5      �� 5    	   -   5        $��刷新��5       $
��Left=�6   $��374,288,0,0q�68   $	��Top=�6M   $��97��6e   $��25��6p   6|   5#      5$      