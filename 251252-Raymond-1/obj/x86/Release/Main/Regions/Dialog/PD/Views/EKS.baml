   M S B A M L   `   `   `  ����   251252-Raymond-1#    HMI.DialogRegion.PD.Views.EKS   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+�� -    �Name$ border��$
��1000��$	��500�� J� RenderTransformOrigin$ 1, 0.5&�$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�
   LocalizableText$
 
@EKS.Text1��$	��400��  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q��� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2��� -   $ 
LayoutRoot��$��	10,0,10,0q�$��2��.+�!  VisiWin.Controls.TextVarOut  -     Name$ status��  TVO_Main#���  $��60��$��Center=�$��0,20,0,0q�$	��Top=�$	��600��*  $VisiWin.Controls.VariableBaseControl   VariableName$ __UNLINKED_BSTR��   LocalizableLabelText$ 
@EKS.Text6��   VisiWin.Controls.TextVarIn  -     Name$
 data��  TVI_Main#���  $��60��$��Center=�$��0,0,0,20q�$��Bottom=�$	��300��$ 
@EKS.Text7��   TextLengthMin$ 4Q�$ __UNLINKED_BSTR��   TextLengthMax$ 5Q�   AuthorizationRight$ PDEKS��  -   $ openConnection��$��45��$	��160�� 
 B_Gray#���  $��0,0,0,0q�$
��Left=�$	��Top=�   LocalizableText$ 
@EKS.Text2��   AuthorizationRight$ PDEKS��  -   $ closeConnection��$��45��$	��160��#���  $��0,55,0,0q�$
��Left=�$	��Top=�$ 
@EKS.Text3��$ PDEKS��  -	   $ readData��$��45��$	��160��#���  $��0,0,0,55q�$
��Left=�$��Bottom=�$ 
@EKS.Text4��$ PDEKS��  -
   $ 	writeData��$��45��$	��160��#���  $��0,0,0,0q�$
��Left=�$��Bottom=�$ 
@EKS.Text5��$ PDEKS��  -   $ updateStatus��$	��100��$	��160��#���  $��Right=�$	��Top=�$ 
@EKS.Text8���� $��3��$��Bottom=�#���  $��2��$ 2��� $��4��.+�  -   $��50��$	��200��$
��Left=�$ @Buttons.Text62��  	B_Gray_ns#���    -   $��50��$	��200��$��Right=�$ @Buttons.Text36��  B_Red_ns#���  $��	0,10,0,10q�