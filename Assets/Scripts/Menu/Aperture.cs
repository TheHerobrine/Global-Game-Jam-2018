using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class Aperture : MonoBehaviour
{
	PostProcessingProfile m_Profile;

	public float time = 0.5f;

	public float DOFfrom;
	public float DOFto;

	public float chrono = 0.0f;

	// Use this for initialization
	void Start ()
	{
		var behaviour = GetComponent<PostProcessingBehaviour>();

		if (behaviour.profile == null)
		{
			enabled = false;
			return;
		}

		m_Profile = Instantiate(behaviour.profile);
		behaviour.profile = m_Profile;
	}
	
	// Update is called once per frame
	void Update ()
	{
		chrono -= Time.deltaTime;
		if (chrono < 0)
		{
			DOFfrom = DOFto;
			if (DOFfrom < 10.0f)
			{
				DOFto = 30.0f;
			}
			else
			{
				DOFto = Random.Range(2.0f, 50.0f);
			}
			chrono += time;
		}

		DepthOfFieldModel.Settings DOFsettings = m_Profile.depthOfField.settings;
		DOFsettings.aperture = (chrono / time) * DOFfrom + (1 - (chrono / time)) * DOFto;
		m_Profile.depthOfField.settings = DOFsettings;
	}
}
