   M S B A M L   `   `   `  ����B  >RSAView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RSAViewRSAView  5   	       RSAView.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:RSAView     5   	     � Title$	  RSA��5      $	��500��6   $	��700��6    � 
ResizeMode$ NoResize=�6*   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $	��300 �6   6+   �� 5      $��25 �6   6*   �� 5      $��45 �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   o� $��45��6   $	��Top=�6   $��0��63   $��0��6@   $��4��6P   .@�5      m� $��File...��6   $��22(�6(   $��5q�66   .@�5      m� -   5         m�Name$ openBtn��5      $
��Open��6,   $��22(�6:   $��5q�6H   6U   m� 5      -   5        $ saveBtn��5      $
��Save��6,   $��22(�6:   $��5q�6H   6U   m� 5      -   5        $ printBtn��5      $��Print��6-   $��22(�6<   $��5q�6J   6W   5      �� 5      6   m� 5      -   5        $ aboutBtn��5      $��About us��6)   $��22(�6;   $��5q�6I   6V   �� 5       6   m� 5!      -   5        $ exitBtn��5!      $
��Exit��6(   $��22(�66   $��5q�6D   6Q   �� 5"      6   m� 5#      -   5        $ GenerateKeyPairs��5#      $��Generate Key Pairs��61   $��5q�6M   $��22(�6X   6i   5$      �� 5%   
   -   5         ��Name$ filenameLabel��5%      $��1��6(   $��18(�65   $��Right=�6C   $��0,0,20,0q�6f   $��0��6x   $��4��6�   6�   �� 5&   
   -   5         ��Name$ contentTextBox��5&       �� 
IsReadOnly$ False��6*   $��2��6=   $��
10,5,10,10q�6J   " �� VerticalScrollBarVisibility$
 Auto=�6^   $	 �� HorizontalScrollBarVisibility$
	 Auto=�6�   $��0��6�   $��5��6�   6�   �� 5'   
   -	   5        
 ��Name$
 	encodeBtn��5'      $��Encode��6%   $��22(�66   $��4��6D   $��1��6Q   $��0,0,10,0q�6a   6u   �� 5(   
   -
   5        $
 	decodeBtn��5(      $��4��6$   $��22(�61   $��Decode��6?   $��2��6P   $��10,0,0,0q�6`   6t   5)      5*      