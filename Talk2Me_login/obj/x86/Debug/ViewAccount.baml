   M S B A M L   `   `   `  ����  Talk2Me_login    Talk2Me_login.ViewAccount   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ViewAccount��5   	   $	��675��6   $
��1087��6*   .��5      � .+�5   
   �� -   5        $��	groupBox1��5   c   $��Account Data��6   $	��199��6)   $
��Left=�66   $��22,9,0,0q�6Q   $	��Top=�6t   $	��454��6�   .��5      � $	��420��6    � ColumnDefinitions 5	      �� 5
      $	��30* �6'   �� 5      $
��158* �6'   .+�5      �� -   5        $��label1��5   c   $��Username��6   $��28��6+   $
��Left=�67   $��6,5,0,0q�6R   $	��Top=�6q   $��2��6�   �� 5      -   5        $��UsernametextBox��5   h    �� AcceptsReturn . $��23��6/   $
��Left=�6;   $��6,39,0,0q�6V    �� TextWrapping$
 Wrap=�6   $	��Top=�6�   $	��120��6�   $��2��6�   �� 5      -   5        $��label12��5   b   $��Email��6   $��28��6(   $
��Left=�64   $��	129,6,0,0q�6O   $	��Top=�6q   $��1��6�   �� 5      -   5        $��EmailTextBox��5   j    . $��23��6/   $
��Left=�6;   $��
129,39,0,0q�6V   $
 Wrap=�6~   $	��Top=�6�   $	��120��6�   $��1��6�   �� 5      -   5        $��label3��5   h   $��New Password��6   $��28��6/   $
��Left=�6;   $��0,68,0,0q�6V   $	��Top=�6v   $��2��6�   �� 5      -   5        $��PasswordTextBox��5   i    . $��23��6/   $
��Left=�6;   $��	4,102,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��2��6�   �� 5      -   5        $��label5��5   r   $��Confirm New Password��6   $��28��67   $
��Left=�6C   $��
123,68,0,0q�6^   $	��Top=�6�   $��1��6�   �� 5      -	   5        $��ConfirmPasswordTextBox��5   k    . $��23��6/   $
��Left=�6;   $��123,102,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��1��6�   5      5      �� 5   
   -
   5        $��	groupBox2��5   f   $��Personal Data��6   $	��200��6*   $
��Left=�67   $��
553,15,0,0q�6R   $	��Top=�6w   $	��484��6�   .��5      � $	��467��6   .+�5      �� -   5        $��label22��5   e   $��
First Name��6   $��28��6-   $
��Left=�69   $��6,3,0,0q�6T   $	��Top=�6t   �� 5      -   5        $��FNamTextBox��5   h    . $��25��6/   $
��Left=�6;   $��6,33,0,0q�6V   $
 Wrap=�6{   $	��Top=�6�   $	��147��6�   �� 5      -   5        $��label23��5   f   $��	Last Name��6   $��28��6,   $
��Left=�68   $��	186,0,0,0q�6S   $	��Top=�6u   �� 5      -   5        $��LNameTextBox��5   k    . $��25��6/   $��Right=�6;   $��
0,33,132,0q�6W   $
 Wrap=�6   $	��Top=�6�   $	��148��6�   �� 5      -   5        $��label9��5   f   $��
Birthplace��6   $��28��6-   $
��Left=�69   $��6,48,0,0q�6T   $	��Top=�6t   �� 5      -   5        $��BirthplaceTextBox��5   h    . $��25��6/   $
��Left=�6;   $��6,78,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��147��6�   �� 5      -   5        $��label10��5   f   $��Birtdate��6   $��28��6+   $
��Left=�67   $��
186,48,0,0q�6R   $	��Top=�6u   �� 5       -   5        $��label7��5    c   $��Gender��6   $��28��6)   $
��Left=�65   $��	6,106,0,0q�6P   $	��Top=�6q   �� 5!      -   5        $��BirtdatetextBox��5!   j    . $��25��6/   $
��Left=�6;   $��
186,78,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��147��6�   �� 5"      -   5        $��GendertextBox��5"   i    . $��25��6/   $
��Left=�6;   $��	8,132,0,0q�6V   $
 Wrap=�6~   $	��Top=�6�   $��65��6�   5#      5$      �� 5%   
   -   5        $��	groupBox3��5%   m   $��Security Information��6   $	��129��61   $
��Left=�6>   $��
45,426,0,0q�6Y   $	��Top=�6~   $	��424��6�   .��5&      �  5'      �� 5(      $��4* �6'   �� 5)      $
��262* �6'   .+�5+      �� -   5        $��label20��5+   Q   $��Secret question��6   $��28��62   $��	19,12,0,0q�6>   $	��Top=�6`   $
��Left=�6x   $	��131��6�   $��1��6�   �� 5,      -   5        $��SecretQuestionTextBox��5,   i    . $��23��6/   $
��Left=�6;   $��	21,46,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   $��1��6�   �� 5-      -   5        $��label21��5-   Q   $��Secret answer��6   $��28��60   $��168,12,34,0q�6<   $	��Top=�6`   $��1��6x   �� 5.      -   5        $��SecretAnswertextBox��5.   j    . $��23��6/   $
��Left=�6;   $��
176,46,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   $��1��6�   5/      50      �� 51   
   -   5        $��	groupBox5��51   p   $��Address and nationality��6   $	��192��64   $
��Left=�6A   $��
26,214,0,0q�6\   $	��Top=�6�   $	��450��6�   .��52      � $	��418��6   .+�53      �� -   5        $��label8��53   N   $��	Telephone��6   $��28��6,   $��164,85,178,0q�68   $	��Top=�6\   �� 54      -   5        $��TelephoneTextBox��54   l    . $��23��6/   $��Right=�6;   $��0,119,134,0q�6W   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   �� 55      -   5        $��label11��55   K   $��Address��6   $��28��6*   $��10,85,251,0q�66   $	��Top=�6Z   �� 56      -   5        $��AddressTextBox��56   j    . $��23��6/   $
��Left=�6;   $��
10,119,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   �� 57      -   5        $��label14��57   L   $��Country��6   $��28��6*   $��154,18,116,0q�66   $	��Top=�6[   �� 58      -    5        $��CountryTextBox��58   j    . $��23��6/   $
��Left=�6;   $��
154,52,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   �� 59      -!   5        $��label15��59   P   $��Current city��6   $��28��6/   $��298,10,39,0q�6;   $	��Top=�6_   �� 5:      -"   5        $��CurrentCityTextBox��5:   j    . $��23��6/   $
��Left=�6;   $��
298,52,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   �� 5;      -#   5        $��label16��5;   M   $��Nationality��6   $��28��6.   $��	10,18,0,0q�6:   $	��Top=�6\   $
��Left=�6t   $	��129��6�   �� 5<      -$   5        $��NationalityTextBox1��5<   i    . $��23��6/   $
��Left=�6;   $��	10,52,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   5=      5>      �� 5?   
   -%   5        $��	groupBox4��5?   l   $��Personal Education��6   $	��192��6/   $
��Left=�6<   $��553,214,0,0q�6W   $	��Top=�6}   $	��476��6�   .��5@      � .+�5A      �� -&   5        $��label18��5A   M   $��	Education��6   $��28��6,   $��11,20,324,0q�68   $	��Top=�6\   �� 5B      -'   5        $��EducationTextBox��5B   i    . $��23��6/   $
��Left=�6;   $��	11,54,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   �� 5C      -(   5        $��label19��5C   L   $��	Languages��6   $��28��6,   $��
286,20,6,0q�68   $	��Top=�6[   �� 5D      -)   5        $��LanguagsTextBox��5D   j    . $��23��6/   $
��Left=�6;   $��
290,54,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   �� 5E      -*   5        $��WorkplaceTextBox��5E   j    . $��23��6/   $
��Left=�6;   $��
144,54,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   �� 5F      -+   5        $��label17��5F   N   $��	Workplace��6   $��28��6,   $��156,20,153,0q�68   $	��Top=�6]   �� 5G      -,   5        $��label2��5G   V   $��Personal Intereset��6   $��28��65   $��11,85,324,0q�6A   $	��Top=�6d   �� 5H      --   5        $��PersonalInteresetTextBox��5H   j    . $��23��6/   $
��Left=�6;   $��
11,119,0,0q�6V   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   5I      5J      5K      5L      