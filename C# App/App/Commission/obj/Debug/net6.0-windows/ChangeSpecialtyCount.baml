   M S B A M L   `   `   `  ����E  ACommission, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Commission
Commission  5   	   %    Commission.ChangeSpecialtyCount   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Commission     5   	     � Title$6  0Изменение количество мест��5   	   $	��640��6+   $
��1000��68    � 
ResizeMode$ NoResize=�6E    � WindowStartupLocation$ CenterScreen=�6[   .��5	      � .+�5
   
   �� $
��Left=�6   $	��102��6+   $��
835,24,0,0q�68   $	��Top=�6L   $��90��6d   $��
/MGUTU.jpg��6o   �� 5   
   $#��(с) 2023 Created by GeorgeL.��6   $
��Left=�67   $��
20,558,0,0q�6R   $	��Top=�6f   $	��179��6~   �� 5   
   $ ��Специальность��6   $
��Left=�6(   $��380,223,0,0q�6C   $	��Top=�6X   $	��120��6p   �� 5   
   -   5         ��Name$ specialtyCodeTextBox��5      $
��Left=�60   $��380,249,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5   
   $6��0Количество бюджетных мест��6   $
��Left=�64   $��380,268,0,0q�6O   $	��Top=�6d   $	��273��6|   �� 5   
   -   5        $ BudgetaryTextBox��5      $
��Left=�6,   $��380,294,0,0q�6G   $
 Wrap=�6\   $	��Top=�6p   $	��120��6�   �� 5   
   -   5        $��Отменить��5      $
��Left=�6$   $��857,544,0,0q�6?   $	��Top=�6T   $��40��6l   $��83��6x   6�   �� 5   
   -   5        $��Сохранить��5      $
��Left=�6%   $��755,544,0,0q�6@   $	��Top=�6U   $��40��6m   $��83��6y   6�   �� 5   
   $<��6Количество внебюджетных мест��6   $
��Left=�67   $��380,315,0,0q�6R   $	��Top=�6g   $	��273��6   �� 5   
   -   5        $ ExtraBudgetaryTextBox��5      $
��Left=�61   $��380,341,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$" ChangeSpecialtyCountDataGrid��5   %      
IsReadOnly$
 True��6      CanUserResizeColumns$ False��6K      CanUserResizeRows$ False��6h   	   CanUserReorderColumns$	 False��6�   
   CanUserSortColumns$
 False��6�      CanUserAddRows$ False��6�      CanUserDeleteRows$ False��6�      AutoGenerateColumns$ False��6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6     SelectionMode$ Single=�6-     SelectionUnit$
 Cell=�6D  $��0,0,699,388q�6Y     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$' !Код специальности��5         
IsReadOnly$
 True��5         Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6'   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ��  �� Path$ Specialty_Code�  5      $ Бюджет��5      $
 True��5      $ 70 6'    62   �� $ Budget_places�  5      $ Внебюджет��5      $
 True��5      $ 80 6'    62   �� $ Extra_budgetary_places�5       5!      5"      