   M S B A M L   `   `   `  ����M  IEncode and  Decode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Encode_and__DecodeEncode_and__Decode  5   	   #    Encode_and__Decode.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Encode_and__Decode     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� $��要转的：��6   $
��Left=�6   $��	10,10,0,0q�6:   $	��Top=�6M   �� 5   
   -   5         ��Name$ TextBox1��5      $
��Left=�6$   $��23��6?   $��	10,41,0,0q�6K    �� TextWrapping$
 Wrap=�6^   $��abc,123,你好��6r   $	��Top=�6�   $	��610��6�   �� 5   
   -   5         ��Name$ Button1��5      $��编码��6"   $
��Left=�6/   $��
667,41,0,0q�6J   $	��Top=�6^   $��75��6v   6�   �� 5   
   $��ASCII格式：��6   $
��Left=�6#   $��
10,105,0,0q�6>   $	��Top=�6R   �� 5   
   -   5        $ TextBox2��5      $
��Left=�6$   $��23��6?   $��
10,136,0,0q�6K   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��610��6�   �� 5   
   -   5        $ Button2��5      $��解码��6"   $
��Left=�6/   $��667,135,0,0q�6J   $	��Top=�6_   $��75��6w   6�   �� 5   
   $��UTF8格式： ��6   $
��Left=�6#   $��
10,202,0,0q�6>   $	��Top=�6R   �� 5   
   -   5        $ TextBox3��5      $
��Left=�6$   $��23��6?   $��
10,245,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��610��6�   �� 5   
   -   5        $ Button3��5      $��解码��6"   $
��Left=�6/   $��667,244,0,0q�6J   $	��Top=�6_   $��75��6w   6�   �� 5   
   $��Unicode格式：��6   $
��Left=�6%   $��
10,305,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ TextBox4��5      $
��Left=�6$   $��23��6?   $��
10,335,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��610��6�   �� 5   
   -   5        $ Button4��5      $��解码��6"   $
��Left=�6/   $��667,335,0,0q�6J   $	��Top=�6_   $��75��6w   6�   �� 5   
   -	   5        $��获取编码信息��5      $��Center=�6"   $��383,391,304.6,0q�6?   $	��Top=�6X   $	��106��6p   6|   5      5      