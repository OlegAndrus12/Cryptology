   M S B A M L   `   `   `  ����C  ?Lab2View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Lab2ViewLab2View  5   	       Lab2View.CipherPad   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Lab2View     5   	     � Title$  	CipherPad��5   	   
������� � 
ResizeMode$ NoResize=�62   $	��375��6H   $	��500��6U   .��5	      �  � RowDefinitions 5
   
   �� 5      $��25 �6   6*   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $��25 �6   6*    � ColumnDefinitions 5   
   �� 5      $��50 �6   6,   �� 5      $	��200 �6   6-   �� 5      $	��200 �6   6-   �� 5      $��50 �6   6,   �� 5      $��50 �6   6,   .+�5   
   �� $��Cipher pad name��6   $��22(�6+   $��1��69   $��1��6I   $��Center=�6V   $��Center=�6q   6�   �� 5   
   -   5         ��Name$ padName��5      $��1��6#   $��2��60   $��20(�6@   $��Center=�6N   $��Center=�6i   $��Center=�6�   $	��200��6�   $��40��6�   6�   �� 5   
   $��Count of pages��6   $��2��6*   $��1��67   $��Center=�6G   $��Center=�6d   $��22(�6   6�   �� 5   
   -   5        $ 
countPages��5      $��2��6&   $��20(�63   $��2��6A   $��Center=�6Q   $��Center=�6l   $��Center=�6�   $	��200��6�   $��40��6�   6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��3��6.   $��1��6;   $��Center=�6K   .+�5      	� -   5         	�Name$ 
ukRadioBtn��5      $��0��6.   $��UK��6>   $��22(�6L   $��4��6\      RadioButtonStyle#��[  6j   $��Center=�6�   $��Center=�6�   6�   �� 5      $��20��6   $y�Hidden=�6#   69   	� 5      -   5        $ enRadioButton��5      $��1��61   $��EN��6A   $��22(�6O   $��4��6^   #��[  6l   $
��Left=�6�   $��Center=�6�   6�   5       �� 5!   
   $ Vertical=�6   $��3��6,   $��2��69   $��Center=�6I   .+�5"      �� $��1��6   $y�Hidden=�6#   69   �� 5#      $��22(�6   $��Gamma Length: ��6&   $��Center=�6<   $��Center=�6W   6v   �� 5$      -   5        $ gammaLength��5$      $��22(�6+   $��Center=�6:   6W   �� 5%      -   5         ��Name$ 
exitWindow��5%      $��OK��6)   $��0,0,0,2q�66   $��0,2,0,0q�6H   $��22(�6Y   6g   5&      5'      5(      