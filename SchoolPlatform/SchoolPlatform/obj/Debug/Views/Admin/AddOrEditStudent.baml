   M S B A M L   `   `   `  ����I  ESchoolPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SchoolPlatform.Views.AdminSchoolPlatform.Views.Admin  5   	   1    +SchoolPlatform.Views.Admin.AddOrEditStudent   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:SchoolPlatform.Views.Admin     5   	     � Title$  AddOrEditStudent��5   	   $	��450��6"   $	��800��6/   .��5	      � .+�5
   
   �� -   5         ��Name$ txtUsername1��5
   "   $
��24px(�6   $
��Left=�68   $��192,114,0,0q�6S    �� TextWrapping$
 Wrap=�6h   $	��Top=�6�   $	��185��6�   $��38��6�   ��6|   �� *NewUser.UserName+6�   �� 5   
   -   5        $ txtPassword1��5   "   $
��24px(�6   $
��Left=�68   $��	192,0,0,0q�6S   $
 Wrap=�6f   $��Center=�6�   $	��185��6�   $��38��6�   ��6z   �� *NewUser.Password+6�   �� 5   
   -   5        $ txtFullName1��5   "   $
��24px(�6   $
��Left=�68   $��192,272,0,0q�6S   $
 Wrap=�6h   $	��Top=�6�   $	��185��6�   $��38��6�   ��6|   �� *NewStudent.StudentName+6�   �� 5   
   $��
Full Name:��6   $
��Left=�6%   $��186,241,0,0q�6@   $	��Top=�6U   �� 5   
   $��	Password:��6   $
��Left=�6$   $��189,167,0,0q�6?   $	��Top=�6T   �� 5   
   $��	UserName:��6   $
��Left=�6$   $��
186,83,0,0q�6?   $	��Top=�6S   �� 5   
   $
��24px(�6   $��Add or Edit Student
��6    $
��Left=�6C   $��
189,34,0,0q�6^   $	��Top=�6r   $��44��6�   $	��280��6�   �� 5   
   -   5        $��Add Student��5   R   $
��Left=�6h   $��192,332,0,0q�6�   $	��Top=�6�   $��38��6�   $	��370��6�   ��6   �� *AddOrEditStudentCommand+6�   �� 5   
   $��420,114,195,254q�6]   ��6   �� *	Classes+ �� SelectedItem 63   �� *NewStudent.Class+��5      �� 5      .R�5      �� $
��18px(�6    ��5      `� 5       �� StringFormat$ {0} {1}��6+   .1�5   "   ��  �� Path$ YearOfStudy.Year�6*   �� 5   "   $' !Specialization.SpecializationName�6*   5      5      5      5      �� 5    
   $��Class:��6   $
��Left=�6!   $��
420,83,0,0q�6<   $	��Top=�6P   5!      5"      