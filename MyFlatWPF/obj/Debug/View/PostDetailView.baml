   M S B A M L   `   `   `  ����D  @MyFlatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MyFlatWPF.ViewMyFlatWPF.View  5      9!clr-namespace:MyFlatWPF.ViewModelMyFlatWPF.ViewModel  5      #    MyFlatWPF.View.PostDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MyFlatWPF.View     5      7	viewModel!clr-namespace:MyFlatWPF.ViewModel     5      .��5      �   � 	Resources  5   
   -   'MyFlatWPF.ViewModel.MainWindowViewModel   MainWindowViewModel  ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%p  &	        &	        5      6,   �� 5      " ��6(   .�5      ��  � ��$ 16(�6-   �� 5       �@�Cursor$
 Hand��6+   �� 5       � �� 5      �� 5      " ��6*   .R�5      �� $ 3��6%   $��1q�5   %   
���   �
����� �._�5   "   �� $��Center=�63   $��Center=�5   3   5      5      5!      5"      5$       � RowDefinitions 5&   
   �� 5'      $��6* �6   �� 5(      $��6* �6   �� 5)      $	��25* �6   �� 5*      $	��10* �6   �� 5+      $	��10* �6    � ColumnDefinitions 5-   
   �� 5.      $��* �6   6+   �� 5/      $��* �6   6+   .+�52   
   �� -   5         ��Name$ tbHeaderPost��52      $��0��53      $��2��54      	 �� Padding$	 	0 20 0 30q�55      $��Center=�56      $��Post Details��57      $��24(�58      $��DemiBold"�59      5:      �� 5<   
   -   5        $ 
tbPostName��5<      $��1��5=      $��2��5>      $��20(�5?      $��Medium"�5@      $��Kithen Design��5A      $��Center=�5B      $
��Left=�5C      $��25 0 0 0q�5D      5F      �� 5H   
   -   5        
 ��Name$
 
iPostImage��5H      $��2��5I      $��0��5J      $1��+C:\repos\MyFlatWPF\MyFlatWPF\Images\b1.jpeg��5K      $
��Left=�5L      $��	25 10 0 0q�5M      5O      �� 5Q   
   -   5        $ tbPostDescription��5Q      $��2��5R      $��2��5S      $��12(�5T      $
��Wrap=�5U      $��20 10 20 10q�5V      ��Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr.Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat.5a      �� 5c   
   -   5         ��Name$ btnBackToBlog��5c      $��3��5d      $��1��5e      $	��100��5f      $��30��5g      $��Right=�5h      $	��Top=�5i      $��	0 10 25 0q�5j      $
��Back��5k       � ToolTip$ To list posts��5l      #��[ 5m      ��5n      �� *SwitchViewCommand+ �� Source# [  ��5o      �� *Name+ �� ElementName$ btnBackToBlog��5q      5s      5t      