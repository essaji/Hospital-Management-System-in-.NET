   M S B A M L   `   `   `  ����>  :HMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HMSHMS  5   	       HMS.Add_Room   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:HMS     5   	   X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�6    � Title$ Add Room��5	   	   $��183.284��6   $��310.15��6+   ���	#FF363636$��1q�6R    � 	Resources 5
         bitSaveImage �� 	UriSource  	saveImage  bitCancelImage  cancelImage��%�   &	        &	 )    7   &	 A     &	 l    7  �� 5   
   $ images/save.png?�6+   �� 5   
   8��  64   �� 5   
   $ images/cancel.png?�6-   �� 5   
   8��  66   5      ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFF2FF9D��6    � Offset$ 1Q�6-   � 5      $ White��6   5      .��5      � .+�5   
   %  Xceed.Wpf.Toolkit.IntegerUpDown  -   5        $��txtTotalBeds��5      $
��Left=�6�   $��
145,43,0,0q�6�   $	��Top=�6�   $	��120��6�   $��26��6�   	 J� RenderTransformOrigin$	 0.515,0.383&�6�   
 � ToolTip
 61   ��  �� RelativeSource �� *Self+ �� Path$) #(Validation.Errors)[0].ErrorContent�,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text 5      �� 5      $ NoOfBeds�6    �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�5       �� NotifyOnValidationError .  �� ValidationRules 5      5  /System.Windows.Controls.ExceptionValidationRule  5      5!      5#      �� 5$   
   -   5         ��Name$ label��5$      $��No. of Beds��6   $
��Left=�65   $��	50,43,0,0q�6P   $	��Top=�6c   $	 1.136,0.506&�6{   �� 5%   
   -   5         ��Name$ cboGovernedBy��5%   �    �� SelectedValuePath$	 nid��6    �� DisplayMemberPath$ employee.firstname��6�   $
��Left=�6�   $��
145,87,0,0q�6�   $	��Top=�6�   $	��120��6  $��26��6  
 6+   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent� �� Text 5&      �� 5'      $ 
GovernedBy�6    . $ PropertyChanged=�5)       .  5+        5,      5.      50      �� 51   
   -   5        $ 
label_Copy��51      $��Governed By��6$   $
��Left=�6:   $��	50,87,0,0q�6U   $	��Top=�6h   $	 1.136,0.506&�6�   �� 52   
   -   5         ��Name$ btnSave��52      #��[ 6"   $
��Left=�6G   $��233,131,0,0q�6b   $	��Top=�6w   $��43��6�   $��42��6�   ��6�   Z� ��6�   Z� �� 53   
   -   5        $ 	btnCancel��53      #��[ 6$   $
��Left=�6K   $��	283,3,0,0q�6f   $	��Top=�6y   $��22��6�   $��23��6�   ��6�   Z� ��6�   Z� 55      56      