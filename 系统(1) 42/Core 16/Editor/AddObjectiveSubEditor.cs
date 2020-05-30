using UnityEngine;
using UnityEditor;


namespace Gamekit3D
{
    public class AddObjectiveSubEditor : SubEditor<ScenarioController>//����������ӱ༭��
    {
        string newObjectiveName = "";//����������
        bool showAdd = false;//Add��ť����ʾ������
        string addError = "";//��ʾ����

        public override void OnInspectorGUI(ScenarioController sc)
        {

            if (!showAdd && GUILayout.Button("Add New Objective")) //GUILayout�����趨��ʾ����ϵͳ���Զ������Ǽ���ؼ���ʾ���򣬲���֤���ص���Ӱ���������ʾЧ���� https://blog.csdn.net/u013289188/article/details/29618897
            {
                showAdd = true;
                GUI.FocusControl("ObjectiveName"); //�ƶ����̽��㵽ObjectiveName�ؼ���
            }
            if (showAdd)
            {                      //using ���ڶ���һ����Χ���ڴ˷�Χ��ĩβ���ͷŶ���
                using (new GUILayout.HorizontalScope()/*���з����������Ԫ�ض��ᱻˮƽ���з���*/)
                {
                    GUI.SetNextControlName("ObjectiveName");//������һ���ؼ�������
                    GUILayout.Label("Objective Name");//����һ���Զ����ֵı�ǩ��
                    newObjectiveName = EditorGUILayout.TextField(newObjectiveName).ToUpper();//TextField����һ�������ı��ֶΣ��û����Ա༭���е��ַ�����toupper����СдӢ����ĸ��Ϊ��Ӧ�Ĵ�д��ĸ
                    using (new EditorGUI.DisabledScope(newObjectiveName == ""))//�����ʱ��û������������֣���������������֡�disabledscope:����һ����Χ������һ���顣
                    {
                        if (GUILayout.Button("Add"))
                        {
                            if (sc.AddObjective(newObjectiveName, 1))//������������������ֺ�������������ӳɹ������������ݽ�������
                            {
                                Close();
                            }
                            else
                            {
                                addError = "This objective name already exists.";
                            }
                        }
                    }
                }
                if (addError != "")
                {
                    EditorGUILayout.HelpBox(addError, MessageType.Error);//��������������Ϊerror������helpbox������ʾ��Ϣ  https://www.cnblogs.com/backlighting/p/5061576.html
                }
                if (Event.current.isKey && Event.current.keyCode == KeyCode.Escape)//�����ʱ���ü��̲��Ҽ���������ΪESC
                {
                    Close();
                }
            }
        }

        void Close()
        {
            newObjectiveName = "";
            addError = "";
            showAdd = false;
            EditorGUIUtility.editingTextField = false;
            Repaint();//�ػ����ؼ�
        }

    } 
}


//����GUILayout��ĺ����Ĳ��ձ� https://blog.csdn.net/likendsl/article/details/50254827
