   M S B A M L   `   `   `  ����  Talk2Me_admin$    Talk2Me_admin.TechnicalSupport   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Talk2Me technical support��5   	   $	��521��6+   $	��346��68   .��5      � .+�5   
   �� -   5        $��tabControl1��5   P   $	��412��6   $
��Left=�6"   $��	12,61,0,0q�6=   $	��Top=�6c   $	��300��6{   .@�5      �� -   5        $��tabItem1��5   /   $��User management��6   .��5      � .+�5	      �� -   5        $��
textBlock1��5	   Z   $��23��6    $
��Left=�6,   $��	14,10,0,0q�6G   $%��Type some contact  information:��6l   $	��Top=�6�   $	��254��6�   �� 5
      -   5        $��textBox1��5
   X   $��23��6   $
��Left=�6*   $��	10,39,0,0q�6E   $	��Top=�6h   $	��264��6�   6�   �� 5      -   5        $��listBox1��5   Y   $	��342��6   $
��Left=�6+   $��	10,68,0,0q�6F   $	��Top=�6i   $	��266��6�   5      5      �� 5      $��Log support��6   .��5      � .+�5      &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5   H      AutoGenerateColumns .  $	��280��6;   $	��274��6Y   $��	8,41,8,59q�6}   ��6e   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6?      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *Date+6d     5      $ Log information��61      MinWidth$ 40Q�6J   $	 170 6X    .  6v   �� *Log+5      �� 5      -   5        $��button1��5   W   $��47��6   $
��Left=�6)   $��	8,327,0,0q�6D   $	��Top=�6f   $��57��6~   ��5      �� 5       �� ImageSource$4 ./Talk2Me_admin;component/bin/Debug/refresh.png��6)   ��5      �� 5      $4 ./Talk2Me_admin;component/bin/Debug/refresh.png��6)   5      5      5      5       �� 5!   
   -   5        $��
textBlock2��5!   O   $��23��6   $
��Left=�6    $��
203,12,0,0q�6;   $��You are loged in as ��6a   $	��Top=�6}   $	��109��6�   �� 5"   
   -	   5        $��UsernameTextBlock��5"   N   $��23��6   $
��Left=�6    $��	58,32,0,0q�6;   $�� ��6g   $	��Top=�6o   $	��254��6�   $��RightToLeft=�6�   5#      5$      