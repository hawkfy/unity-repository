using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
	public AudioClip m_goalClip;

	private bool m_isGoal;

	private void OnTriggerEnter2D( Collider2D other )
	{
		if ( !m_isGoal )
		{
			if ( other.name.Contains( "Player" ) )
			{		
				var cameraShake = FindObjectOfType<CameraShaker>();
				cameraShake.Shake();
				m_isGoal = true;
				var animator = GetComponent<Animator>();
				animator.Play( "Pressed" );
				var audioSource = FindObjectOfType<AudioSource>();
				audioSource.PlayOneShot( m_goalClip );
				var activeScene = SceneManager.GetActiveScene().name;
				if(activeScene == "Stage1"){
					SceneManager.LoadScene("Stage2");
				}else if(activeScene == "Stage2"){
					SceneManager.LoadScene("Stage3");
				}
				m_isGoal = false;
			}
		}
	}
}