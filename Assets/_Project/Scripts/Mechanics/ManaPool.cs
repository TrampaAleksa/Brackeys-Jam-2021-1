using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPool : MonoBehaviour
{
   public static ManaPool Instance;

   public float remainingMana;
   public float resurrectionCost;
   public float retreatCost;

   private void Awake()
   {
      Instance = this;
   }


   public void ReduceMana(float amount)
   {
      remainingMana -= amount;
   }
   
   public void AddMana(float amount)
   {
      remainingMana += amount;
   }

   public void CastedResurrection()
   {
      ReduceMana(resurrectionCost);
   }
   
   public void CastedRetreat()
   {
      ReduceMana(retreatCost);
   }
   
}
