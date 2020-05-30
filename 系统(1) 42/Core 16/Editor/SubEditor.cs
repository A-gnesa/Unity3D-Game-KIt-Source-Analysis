using UnityEditor;

namespace Gamekit3D
{
	//������Ҫ���ڶԻ�������ö�����ί�н���ʹ�ò����
        //�����ࣺ�ӱ༭������������ʵ��  ����abstract����ϸ˵��https://blog.csdn.net/yk_lin/article/details/83469094
        //����<T> https://www.sogou.com/link?url=hedJjaC291OB0PrGj_c3jJzmXqp0xreSchXwq6KZroyroHKd7_5kXCbc-iPH6wf8jzYWkh2yY3ynXTW0b-n0YQ..
    public abstract class SubEditor<T>
    {
        public abstract void OnInspectorGUI(T instance);

        public void Init(Editor editor)//��õ�ǰ�༭��
        {
            this.editor = editor;
        }

        public void Update()
        {
            if (defer != null) defer();//�����ǰί�в�Ϊ�գ������е�ǰί�У�Ȼ���ٴ���Ϊ��
            defer = null;
        }

        protected void Defer(System.Action fn)//��ί�������Ҫִ�еķ���
        {
            defer += fn;
        }

        protected void Repaint()//�����ػ�������еĿؼ�
        {
            editor.Repaint();
        }

        Editor editor;
        System.Action defer;//һ������ί��  https://blog.csdn.net/qq_38187606/article/details/78928876
    } 
}
