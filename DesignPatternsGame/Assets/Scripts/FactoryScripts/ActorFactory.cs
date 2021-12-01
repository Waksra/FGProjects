using UnityEngine;
using ActorScripts;

namespace FactoryScripts
{
	[CreateAssetMenu(fileName = "NewActorFactory", menuName = "Factory/ActorFactory")]
	public class ActorFactory : GenericFactory<Actor>
	{
	
	}
}
