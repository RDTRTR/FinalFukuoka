using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotate : MonoBehaviour
{
    //�I�u�W�F�N�g��ϐ��Ɋi�[
    public GameObject Stage;
    public GameObject Camera;

    public bool rotateFlag = false;

    //���J����������ꏊ��c������
    public int count;

    void Start()
    {
        
    }

    void Update()
    {

        //�{�^�����N���b�N���ꂽ��������������
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //�X�e�[�W�ʒu���
        Vector3 stagePos = Stage.transform.position;

        //�J��������]������
        //���N���b�N
        if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(0))
        {
            //�J����������Ă���Ƃ��͑���ł��Ȃ��悤�ɂ���
            if (!rotateFlag)
            {
                rotateFlag = true;

                count += 1;

                //���������J�E���g�����Z�b�g
                if (count > 3)
                {
                    count = 0;
                }

               // Debug.Log(count);

                //����]�Ăяo��
                StartCoroutine(LeftMove());
            }

        }

        //�E�N���b�N
        if (Input.GetMouseButton(1) && Input.GetMouseButtonDown(1))
        {
            //�J����������Ă���Ƃ��͑���ł��Ȃ��悤�ɂ���
            if (!rotateFlag)
            {
                rotateFlag = true;

                //������ꏊ���X�V
                count -= 1;

                //���������J�E���g�����Z�b�g
                if (count < -3)
                {
                    count = 0;
                }

                //Debug.Log(count);

                //�E��]�Ăяo��
                StartCoroutine(RightMove());
            }

        }

    }


    //�E��]
    IEnumerator RightMove()
    {
        //���S�����߂�
        Vector3 playerPos = Stage.transform.position;

        //��]���� 0.01�b��1�x��]����(1�b��90�x)
        for (int turn = 0; turn < 90; turn++)
        {
            transform.RotateAround(playerPos, new Vector3(0, -1, 0), 1.0f);
            yield return new WaitForSeconds(0.01f);
        }

        //��]���͉�]���Ȃ��悤�ɂ���
        rotateFlag = false;

    }

    //����]
    IEnumerator LeftMove()
    {
        //���S�����߂�
        Vector3 playerPos = Stage.transform.position;

        //��]���� 0.01�b��1�x��]����(1�b��90�x)
        for (int turn = 0; turn < 90; turn++)
        {
            transform.RotateAround(playerPos, new Vector3(0, 1, 0), 1.0f);
            yield return new WaitForSeconds(0.01f);
        }

        //��]���͉�]���Ȃ��悤�ɂ���
        rotateFlag = false;

    }

}