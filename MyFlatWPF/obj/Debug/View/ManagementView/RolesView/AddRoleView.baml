   M S B A M L   `   `   `  ����D  @MyFlatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:MyFlatWPF.View.ManagementView.RolesView'MyFlatWPF.View.ManagementView.RolesView  5      O,clr-namespace:MyFlatWPF.ViewModel.ManagementMyFlatWPF.ViewModel.Management  5      =#clr-namespace:MyFlatWPF.HelpMethodsMyFlatWPF.HelpMethods  5      9    3MyFlatWPF.View.ManagementView.RolesView.AddRoleView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:MyFlatWPF.View.ManagementView.RolesView     5      B	viewModel,clr-namespace:MyFlatWPF.ViewModel.Management     5      4help#clr-namespace:MyFlatWPF.HelpMethods     5      .��5      � -   5          �Name$  gAddUser��5      $��	10 0 10 0q�5       � 	Resources 5   
   5   /MyFlatWPF.ViewModel.Management.AddRoleViewModel   AddRoleViewModel1  +MyFlatWPF.HelpMethods.MyMultiValueConverter  MultiValueConverter  BorderStyle �� 
TargetType �� Property �� Value  ButtonStyle �� 
TargetType ��Name �� CornerRadius �� Padding  ButtonHoverStyle  InputTextBox	 J� SnapsToDevicePixels
 ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	      &	 &     &	 �     &	 �    &	 5      5      6)     5      6)   �� 5      " ��6(   .�5      ��  � ��
 ��·�6F   �� 5       � ��$	 0.5��6+   69   5      �� 5      " ��6(   .�5      ��  � ��$ 10(�6-   �� 5       �@�Cursor$
 Hand��6+   �� 5       � ��$ 20��6+   �� 5       � ��$ 5 0 5 0q�6,   �� 5       � ��
 �   �60   �� 5        � ��$
 0.75q�64   �� 5!       � �� 5"      �� 5#      " ��6*   .R�5$      �� $ border��6%   $ 3��5%   %   $��20��5&   %   $ 5 0 5 0q�5'   %   $��Center=�5(   %   $��Center=�5)   %   $��1q�5*   %   
���   �
����� �._�5-   "   �� $��Center=�63   $��Center=�5.   3   5/      50      52      53      �� 55      " ��6-   .�56      ��  � ��$ 10(�6-   �� 57       �@�Cursor$
 Hand��6+   �� 58       � ��$ 20��6+   �� 59       � ��$ 5 0 5 0q�6,   �� 5:       � ��
 �   �60   �� 5;       � ��$ 1q�64   �� 5<       � �� 5=      �� 5>      " ��6*   .R�5?      �� $ border��6%   $ 3��5@   %   $��20��5A   %   $ 5 0 5 0q�5B   %   $��Center=�5C   %   $��Center=�5D   %   $��1q�5E   %   
���   ����#0082ff._�5H   "   �� $��Center=�63   $��Center=�5I   3   5J      5K      5M      5N      �� 5P      " ��6)   .�5Q      ��  � ��$ 0q�6,   �� 5R       � ��
 �����60   �� 5S       � ��$
 0.75q�64   �� 5T       � �� 5U      �� 5V      " ��6*   .R�5W      �� $ border��5X      #��z��5Y      #��z��5Z      #��z��5[      	 . $ 2��5]   !   ._�5^   "   �� $
 PART_ContentHost��5_      |�.  $��Hidden=�5a      $��Hidden=�5b      5c       5d      P� 5e   "    �@J�IsMouseOver . . �5f   &   �� $ border��6-    � �� �	#FF7EB4EA6X   �� 5g   &   $ border��6-    � ��$
 0.75q�6\   5h   #   P� 5i   "    �@J�	IsFocused . . �5j   &   �� $ border��6-    � ��
 ��  �6X   �� 5k   &   $ border��6-    � ��$ 1q�6\   5l   #   5n      5p      5q      5s       � RowDefinitions 5u   
   �� 5v      $
��0.6* �6   �� 5w      $
��0.3* �6   �� 5x      $
��0.4* �6   �� 5y      $
��0.4* �6   �� 5z      $
��0.6* �6   �� 5{      $	��10* �6    � ColumnDefinitions 5}   
   �� 5~      $��* �6   6+   .+�5�   
   �� -   5         ��Name$ 
tblAddRole��5�      $��Add Role��5�      $��20(�5�      $��0 5 0 5q�5�      5�      �� 5�   
   $��1��6   $��0 5 0 0q�5�      #��[ 5�      6@   �� 5�   
   -   5        $ tblRoleName��5�      $��2��5�      $��	Role name��5�      $��16(�5�      $��0 10 0 0q�5�      $
��Left=�5�      5�      �� 5�   
   -   5         ��Name$ 
tbRoleName��5�      $��3��5�      $	��150��5�      $��20��5�      $��12(�5�      $��0 0 0 0q�5�      $
��Left=�5�      $��Bottom=�5�      ��5�      ��  �� Source# [ .��6K   5�      �� 5�   
   -   5         ��Name$ lErrorRoleName��5�      $��3��5�      $��12(�5�      
���  ��$��	160 5 0 0q�5�      5�      �� 5�   
   -   5         ��Name$ 
btnAddRole��5�      $��4��5�      $	��Add��5�      $��DemiBold"�5�       � ToolTip$ Add role��5�      $
��Left=�5�      $	��Top=�5�      $��0 10 0 0q�5�      #��[ 5�      ��5�      �� *AddRoleCommand+# [  ��5�      `� 5�       `� 	Converter# [ 6   .1�5�      ��  �� ElementName$ 
tbRoleName��6   �� 5�      $ lErrorRoleName��6   5�      5�      5�      5�      