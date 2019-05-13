using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    [SerializeField]
    private string nombre;
    [SerializeField]
    private int size;
    [SerializeField]
    private float baseValue;

  //public Package(string _name, int _size, float _baseValue)
  //  {
  //      nombre = _name;
  //      size = _size;
  //      baseValue = _baseValue;
  //  }

   
    public string Nombre { get => nombre; protected set => nombre = value; }
    public int Size { get => size; protected set =>  size = value; }
    public float BaseValue { get => baseValue; protected set => baseValue = value; }
}
