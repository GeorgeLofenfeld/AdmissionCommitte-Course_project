   M S B A M L   `   `   `  ����E  ACommission, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Commission
Commission  5   	       Commission.HomeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Commission     5   	   -   5          � Title$  Главная��5   	   $	��640��6   $
��1000��6&    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I   .��5	      � .+�5
   
   �� -   5        $��
Выход��5
      $
��Left=�6!   $��857,544,0,0q�6<   $	��Top=�6Q   $��40��6z   $��83��6�   �� 5   
   -   5        $��Справка��5      $
��Left=�6#   $��
680,84,0,0q�6>   $	��Top=�6R   $��40��6{   $	��119��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ HomeDataGrid��5   %      
IsReadOnly$
 True��6      CanUserResizeColumns$ False��6;      CanUserResizeRows$ False��6X      CanUserReorderColumns$ False��6r      CanUserSortColumns$ False��6�   	   CanUserAddRows$	 False��6�   
   CanUserDeleteRows$
 False��6�   $��
5,144,5,85q�6�      AutoGenerateColumns$ False��6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6     SelectionMode$ Single=�61     SelectionUnit$
 Cell=�6H     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��5         
IsReadOnly$
 True��5         Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6'   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ��  �� Path$ lastName�  5      $ Имя��5      $
 True��5      $	 120 6'    63   �� $ 	firstName�  5      $ Отчество��5      $
 True��5      $	 120 6'    63   �� $ 
middleName�  5      $ Дата рождения��5      $
 True��5      $	 121 6'    63   �� $ dateOfBirth�  5      $' !Код специальности��5      $
 True��5      $	 132 6'    63   �� $ specialtyCode�  5      $ Средний балл��5      $
 True��5      $ 95 6'    62   �� $ averageScore�  5       $. (Дата подачи заявления��5!      $
 True��5"      $	 145 6'    63   �� $ dateOfStatement�  5#      $# Номер заявления��5$      $
 True��5%      $	 111 6'    63   �� $ numberOfStatement�5'      �� 5(   
   -   5        $#��Сохранить отчёт��5(      $
��Left=�6+   $��
680,24,0,0q�6F   $	��Top=�6Z   $��40��6r   $	��118��6~   6�   �� 5)   
   -   5        $H��BПросмотр, изменение количества мест��5)      $
��Left=�6?   $��
420,24,0,0q�6Z   $	��Top=�6n   $��40��6�   $	��240��6�   6�   �� 5*   
   -   5        $F��@Просмотр, редактирование, удаление��5*      $
��Left=�6>   $��
160,24,0,0q�6Y   $	��Top=�6m   $��40��6�   $	��240��6�   6�   �� 5+   
   -   5        $)��#Добавить заявление��5+      $
��Left=�6.   $��	20,24,0,0q�6I   $	��Top=�6\   $��40��6t   $	��118��6�   6�   �� 5,   
   $��Фильтр:
��6   $
��Left=�6'   $��	15,99,0,0q�6B   $	��Top=�6U   $��25��6m   $��59��6y   �� 5-   
   $!��Специальность:��6   $
��Left=�6)   $��	79,77,0,0q�6D   $	��Top=�6W   $	��120��6o   �� 5.   
   $��Год подачи:��6   $
��Left=�6&   $��
220,77,0,0q�6A   $	��Top=�6U   $	��120��6m   �� 5/   
   $#��(с) 2023 Created by GeorgeL.��6   $
��Left=�67   $��
20,558,0,0q�6R   $	��Top=�6f   $	��179��6~   �� 50   
   $
��Left=�6   $	��102��6+   $��
835,24,0,0q�68   $	��Top=�6L   $��90��6d   $��	MGUTU.jpg��6o   �� 51   
   $
��Left=�6   $��220,104,0,0q�6-    �� TextWrapping$
 Wrap=�6B   $	��Top=�6V   $	��120��6n   $��21��6z   �� 52   
   $
��Left=�6   $��
79,104,0,0q�6-   $
 Wrap=�6A   $	��Top=�6U   $	��120��6m   $��21��6y   �� 53   
   -	   5         ��Name$ countOfStatementsLabel��53      $��[count of statements]��60   $
��Left=�6P   $��410,558,0,0q�6k   $	��Top=�6�   $	��220��6�   $��26��6�   �� 54   
   $��Обновить��6   $
��Left=�6$   $��
541,84,0,0q�6?   $	��Top=�6S   $��40��6k   $	��119��6w   	� 55   
   $��Бюджет��6   $
��Left=�6'   $��360,114,0,0q�6B   $	��Top=�6W   	� 56   
   $��Внебюджет��6   $
��Left=�6*   $��
360,97,0,0q�6E   $	��Top=�6Y   	� 57   
    d� 	IsChecked$
 TrueY�6   $��Все��6'   $
��Left=�65   $��460,110,0,0q�6P   $	��Top=�6e   58      59      