   M S B A M L   `   `   `  ����D  @MyFlatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MyFlatWPF.ViewMyFlatWPF.View  5      9!clr-namespace:MyFlatWPF.ViewModelMyFlatWPF.ViewModel  5      !    MyFlatWPF.View.ProjectsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MyFlatWPF.View     5      7	viewModel!clr-namespace:MyFlatWPF.ViewModel     5      .��5      �   � 	Resources  5   
      HoverButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType��%8  &	        �� 5      " ��6-   .�5      ��  �@�OverridesDefaultStyle . 6:   �� 5       � ��$
 Left=�68   �� 5       � �� 5      �� 5      " ��6*   .R�5      �� #��z��6%   ._�5   "   �� $��Center=�63   $��Center=�5   3   5      5      5      5      5       � RowDefinitions 5    
   �� 5!      $	��20* �6   �� 5"      $	��15* �6   �� 5#      $
��140* �6    � ColumnDefinitions 5%   
   �� 5&      $��* �6   6+   .+�5)   
   �� -   5         ��Name$ tbHeaderProjects��5)      $��0��5*       �� Padding$ 	0 20 0 10q�5+      $��Center=�5,      $��Our Projects��5-      $��24(�5.      $��DemiBold"�5/      50      �� 52   
   -   5        $ tbCommonDescription��52      $��1��53      $��11(�54      $��Center=�55      $��	0 10 0 10q�56      HFAs a builder, we undertake large, complex projects, foster innovation,�� 57   [   @>emerging technologies, and make a difference in the community.59      � 5;   
   -   5        	 �Name$	 
wpProjects��5;      $��2��5<      $��Center=�5=      $��20 20 25 20q�5>      
 � Orientation$
 
Horizontal=�5?      5A      5C      5D      