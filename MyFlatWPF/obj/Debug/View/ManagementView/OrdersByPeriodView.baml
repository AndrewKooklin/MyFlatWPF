   M S B A M L   `   `   `  ����D  @MyFlatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:MyFlatWPF.View.ManagementViewMyFlatWPF.View.ManagementView  5      O,clr-namespace:MyFlatWPF.ViewModel.ManagementMyFlatWPF.ViewModel.Management  5      6    0MyFlatWPF.View.ManagementView.OrdersByPeriodView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:MyFlatWPF.View.ManagementView     5      B	viewModel,clr-namespace:MyFlatWPF.ViewModel.Management     5      .��5      �   � 	Resources  5   
   <   6MyFlatWPF.ViewModel.Management.OrdersByPeriodViewModel   OrdersByPeriodViewModel  ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  ButtonByPeriodStyle  DatePickerStyle(  "System.Windows.Controls.DatePicker��%�  &	        &	      &	 �    &	 �      5      60   �� 5      " ��6(   .�5      ��  � ��$ 30��6+   �� 5       � ��$ 12(�6-   �� 5       � ��$ SemiBold"�6/   �� 5       �@�Cursor$
 Hand��6+   �� 5       � ��$ Center=�66   �� 5       � ��$ 3 0 0 0q�6+   �� 5       � �� 5      �� 5      " ��6*   .R�5      �� $ 3��6%   $��1q�5   %   
���   �
����� �._�5   "   �� $��Center=�63   $��Center=�5    3   5!      5"      5$      5%      �� 5'      " ��60   .�5(      ��  � ��$ 30��6+   �� 5)       � ��$ 12(�6-   �� 5*       � ��$ SemiBold"�6/   �� 5+       �@�Cursor$
 Hand��6+   �� 5,       � ��$ Center=�66   �� 5-       � ��$ 3 0 0 0q�6+   �� 5.       � �� 5/      �� 50      " ��6*   .R�51      �� $ 3 0 0 3��6%   $��1 1 0 1q�52   %   
���   �
����� �._�55   "   �� $��Center=�63   $��Center=�56   3   57      58      5:      5;      �� 5=      "  6,   .�5>      ��  � ��$ 30��6+   �� 5?       � ��$	 105��6*   �� 5@       � ��$ 12(�6-   �� 5A       �@�Cursor$
 Hand��6+   �� 5B       � ��
 ��� �6/   �� 5C       � ��$ Center=�66   �� 5D       � ��$
 Left=�68   �� 5E       � ��$ 0 0 0 0q�6+   �� 5F       � ��
 �   �60   5G      5I       � RowDefinitions 5K   
   �� 5L      $	��15* �6   �� 5M      $��4* �6   �� 5N      $	��10* �6   �� 5O      $	��10* �6   �� 5P      $
��140* �6    � ColumnDefinitions 5R   
   �� 5S      $��* �6   6+   .+�5V   
   �� -   5         ��Name$ 	spHeaders��5V      $��0��5W      $��
25 20 0 10q�5X      	 �� Orientation$	 
Horizontal=�5Y      $
��Left=�5Z      .+�5\      �� -   5        
 ��Name$
 tbHeader��5\      $��Orders by :��5]      $��24(�5^      $
��Left=�5_      5`      �� 5b      -   5        $
 tbHeaderPeriod��5b      $��24(�5f      $��5 0 0 0q�5g      $
��Left=�5h      ��5c      �� *
PeriodName+ �� Source# [   �� UpdateSourceTrigger$ PropertyChanged=�5i      5k      �� 5m   
   -   5        $
 tbErrorPeriod��5m      $��1��5n      $��2��5o      $��12(�5s      
���  ��$��0 0 30 0q�5u      $��Right=�5v      ��5p      �� *ErrorPeriod+# [  $ PropertyChanged=�5w      �� 5y   
   -   5        $ spOrdersByPeriod��5y      $��2��5z      $��2��5{      $	 
Horizontal=�5|      $��Center=�5}      $��5 0 0 0q�5~      .+�5�      �� -   5         ��Name$ btnToday��5�      $��55��5�      $��Today��5�      $��20 0 0 0q�5�       � ToolTip$ Orders for Today��5�      #��[ 5�      ��5�      �� *ShowOrdersByPeriodCommand+# [  ��5�      �� *Name+ �� ElementName$ btnToday��5�      �� 5�      -   5        $ btnYesterday��5�      $��70��5�      $��	Yesterday��5�      $ Orders for Yesterday��5�      #��[ 5�      ��5�      �� *ShowOrdersByPeriodCommand+# [  ��5�      �� *Name+$ btnYesterday��5�      �� 5�      -   5        $ btnWeek��5�      $��50��5�      $
��Week��5�      $ Orders for Week��5�      #��[ 5�      ��5�      �� *ShowOrdersByPeriodCommand+# [  ��5�      �� *Name+$ btnWeek��5�      �� 5�      -	   5        $ btnMonth��5�      $��55��5�      $��Month��5�      $ Orders for Month��5�      #��[ 5�      ��5�      �� *ShowOrdersByPeriodCommand+# [  ��5�      �� *Name+$ btnMonth��5�      �� 5�      -
   5        $ 	btnPeriod��5�      $��80��5�      $��Period from��5�      $ Orders by Period��5�      #��[ 5�      ��5�      �� *ShowOrdersByPeriodCommand+# [  ��5�      �� *Name+$ 	btnPeriod��5�        5�        Language$ en-US�5�      -   5          Name$ 
dpDateFrom��5�      #��[ 5�      $ 	Date from��5�      $��0 1 0 1q�5�         FirstDayOfWeek$ Monday=�5�      $��0 5 0 5q�5�         Text 5�      �� *
DateFrom+# [    5�      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� Path �� StringFormat �� RelativeSource �� AncestorType��%L  '        �� 5�      "  6   .�5�      ��  �@��
IsReadOnly . 67   �� 5�       � |� .  66   �� 5�       � �� 5�      �� 5�   "   .R�5�   &   �� $ TextBoxFrom��6.   $��5 0 0 0q�5�   .   ��5�   .   �� $ SelectedDate�$ 
dd.MM.yyyy�� �� "  5�   .   5�   #   5�      5�      5�      5�      �� 5�      $��30��6   $��20��5�      $
��Left=�5�      
����� �
���   �$��0 1 0 1q�5�      $��Center=�5�      ._�5�      �� $��to��6   $��20��5�      $��12(�5�      $��SemiBold"�5�       �� Padding$ 4 0 0 0q�5�      $��Center=�5�      5�      5�        5�      $ en-US�5�      -   5        $ dpDateTo��5�      #��[ 5�      $ Date to��5�      $��0 1 0 1q�5�      $ Monday=�5�      $��0 5 0 5q�5�       5�      �� *DateTo+# [    5�      ��%J  '        �� 5�      "  6   .�5�      ��  �@��
IsReadOnly . 67   �� 5�       � |� .  66   �� 5�       � �� 5�      �� 5�   "   .R�5�   &   �� $ 	TextBoxTo��6.   $��5 0 0 0q�5�   .   ��5�   .   �� $ SelectedDate�$ 
dd.MM.yyyy�� �� "  5�   .   5�   #   5�      5�      5�      5�      �� 5�      $��30��6   $��5��5�      $
��Left=�5�      
����� �
���   �$��0 1 1 1q�5�      $ 0 3 3 0��5      5     5     �� 5  
   -   5        $ spCount��5     $��3��5     $��2��5     $��	25 10 0 0q�5     $	 
Horizontal=�5	     .+�5     �� -   5        $
 tbOrdersCountText��5     $��Orders Count : ��5     $��20(�5     $��Center=�5     5     �� 5     -   5        $
 tbOrdersCount��5     $��20(�5     $��Center=�5     $
��Left=�5     ��5     �� *OrdersCount+# [  $ PropertyChanged=�5     5     &   System.Windows.Controls.DataGrid  5  
   -   5          Name$ dgOrders��5     $��4��5     $��2��5     $	��600��5     $	��450��5     $��
10 0 10 20q�5      
������ 
������ $��0 1 0 0q�5#     $��Center=�5$     $��Center=�5%     "   VerticalScrollBarVisibility$
 Auto=�5&        CanUserAddRows .     AutoGenerateColumns .  $��	0 10 0 20q�5-     ��5)     �� *Orders+# [  $ PropertyChanged=�   Columns 5.     0  *System.Windows.Controls.DataGridTextColumn  50     ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%       Width5  /System.Windows.Controls.DataGridLengthConverter$  20 51  !   !   
IsReadOnly! . 1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 53  !   �� *Id+$ PropertyChanged=�#   	CellStyle# 55     �� 56     *	  $System.Windows.Controls.DataGridCell" 	 6    .�57     ��  � ��
 �   �6<   �� 58      � ��$ 	0.8 0 0 0q�6@   59     $   HeaderStyle$ 5;     �� 5<     =
  7System.Windows.Controls.Primitives.DataGridColumnHeader" 
 6    .�5=     ��  � ��$ Center=�6K   �� 5>      � ��
 �����6;   �� 5?      � ��$ 1 1 1 1q�6@   �� 5@      � ��
 �   �6<   5A     %   ElementStyle% 5C     �� 5D     .�5E     ��  � ��$ Center=�6N   �� 5F      � ��$ Center=�6L   5G     5I       5K     $ Date Create��6%   $  75 5L  !   ! . " 5N  !   �� *
DateCreate+$ dd.MM.yyyy HH:mm:ss��& �� Mode$& OneWay=�$ 5Q     �� 5R     " 
 6    .�5S     ��  � ��$ Center=�6K   �� 5T      � ��
 �����6;   �� 5U      � ��$ 0 1 1 1q�6@   �� 5V      � ��
 �   �6<   5W     % 5Y     �� 5Z     .�5[     ��  � ��$
 Wrap=�6G   �� 5\      � ��$ Center=�6N   �� 5]      � ��$ Center=�6L   5^     5`       5b     $
 Name��6%   $  60 5c  %   ! . " 5e  %   �� *Name+$ 5f     �� 5g     " 
 6    .�5h     ��  � ��$ Center=�6K   �� 5i      � ��
 �����6;   �� 5j      � ��$ 0 1 1 1q�6@   �� 5k      � ��
 �   �6<   5l     % 5n     �� 5o     .�5p     ��  � ��$
 Wrap=�6G   �� 5q      � ��$ Center=�6N   �� 5r      � ��$ Center=�6L   5s     5u       5w     $ Email��6%   $  80 5x  %   ! . " 5z  !   �� *Email+$ 5{     �� 5|     " 
 6    .�5}     ��  � ��$ Center=�6K   �� 5~      � ��
 �����6;   �� 5      � ��$ 0 1 1 1q�6@   �� 5�      � ��
 �   �6<   5�     % 5�     �� 5�     .�5�     ��  � ��$
 Wrap=�6G   �� 5�      � ��$ Center=�6N   �� 5�      � ��$ Center=�6L   5�     5�       5�     $ Mobile��6%   ! . " 5�  !   �� *Mobile+$ 5�     �� 5�     " 
 6    .�5�     ��  � ��$ Center=�6K   �� 5�      � ��
 �����6;   �� 5�      � ��$ 0 1 1 1q�6@   �� 5�      � ��
 �   �6<   5�     % 5�     �� 5�     .�5�     ��  � ��$
 Wrap=�6G   �� 5�      � ��$ Center=�6N   �� 5�      � ��$ Center=�6L   5�     5�       5�     $ Message��6%   $  80 5�  !   '   FontSize$' 8Q�5�  !   ! . " 5�  !   �� *	Message+$ 5�     �� 5�     " 
 6    .�5�     ��  � ��$ Center=�6K   �� 5�      � ��
 �����6;   �� 5�      � ��$ 0 1 1 1q�6@   �� 5�      � ��
 �   �6<   5�     % 5�     �� 5�     .�5�     ��  � ��$
 Wrap=�6G   �� 5�      � ��$ Center=�6N   �� 5�      � ��$ Center=�6L   5�     5�       5�     $ Service Name��6%   $  * 5�  %   $' 10Q�5�  %   ! . " 5�  %   �� *ServiceName+$ 5�     �� 5�     " 
 6    .�5�     ��  � ��$ Center=�6K   �� 5�      � ��
 �����6;   �� 5�      � ��$ 0 1 1 1q�6@   �� 5�      � ��
 �   �6<   5�     % 5�     �� 5�     .�5�     ��  � ��$
 Wrap=�6G   �� 5�      � ��$ Center=�6N   �� 5�      � ��$ Center=�6L   5�     5�     4  .System.Windows.Controls.DataGridTemplateColumn  5�     -   5        
dgComboBox��$ Status Name (changeable)��5�  )   $  90 5�  )   $ 5�     �� 5�     " 
 6    .�5�     ��  � ��$ Center=�6K   �� 5�      � ��
 �����6;   �� 5�      � ��$ 0 1 1 1q�6@   �� 5�      � ��
 �   �6<   �� 5�      � �� 5�  "   �� 5�  &   .R�5�  *   �� $
��Wrap=�64   $��12(�5�  4   ��5�  4   �� 5�  +   5�  '   5�     5�     (   CellTemplate( 5�     �� 5�     .R�5�     �� ) ��Name$) cbStatus��6'   -   5        
������ $��0 0 0 0q�5�  '   ��5�  !   �� *StatusNames+# [  * �� SelectedItem* 5�     �� *
StatusName+5�  '   5�     5�     5�     5�     5�     