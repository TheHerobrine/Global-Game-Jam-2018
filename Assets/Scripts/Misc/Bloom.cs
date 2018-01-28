using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class Bloom : MonoBehaviour
{
	public EnvironmentManager manager;
	PostProcessingProfile m_Profile;

	public float time = 0.5f;

	public float fade;

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
		if (manager.outside)
		{
			fade += Time.deltaTime * time;
		}
		else
		{
			fade -= Time.deltaTime * time;
		}

		fade = Mathf.Clamp01(fade);

		

		BloomModel.Settings bloomSettings = m_Profile.bloom.settings;
		bloomSettings.bloom.threshold = 1.0f + fade;
		m_Profile.bloom.settings = bloomSettings;
	}
}
