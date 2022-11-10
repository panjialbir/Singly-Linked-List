using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singly_linked_list
{
    class Node
    {
        public int noMhs;
        public string nama;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        //Method untuk menambahkan sebuah node ke dalam list

        public void addNote()
        {
            int nim;
            string nm;
            Console.WriteLine("\nMasukan nomer Mahasiswa: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukan nama Mahasiswa: ");
            nm = Console.ReadLine();

            Node nodeBaru = new Node();
            nodeBaru.noMhs = nim;
            nodeBaru.nama = nm;

            //Node ditambahkan sebagai node pertama
            if (START == null || nim <= START.noMhs)
            {
                if ((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nNomer mahasiswa sama tidak diizinkan ");
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;
            }
            //Menemukan lokasi node baru didalam list
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nim >= current.noMhs))
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("\nNomer mahasiswa sama tidak diizinkan");
                    return;
                }
                previous = current;
                current = current.next;
            }
            //Node baru akan ditempatkan di antara previous dan current
            nodeBaru.next = current;
            previous.next = nodeBaru;
        }

        //Method untuk menghapus node tertentu didalam list
        public bool delNode(int nim)
        {
            Node previous, current;
            previous = current = null;
            //check apakah node yang dimaksud ada di dalam list atau tidak
            if (Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)

                START = START.next;
            return true;

        }
        //Method untuk meng-check apakah node yang dimaksud ada di dalam list atau tidak
        public bool Search(int nim, ref Node previous, ref Node current)
        {
            previous = current;
            while ((current != null) && (nim != current.noMhs))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        //Method untuk treverse /mengunjungi dan membaca isi list
        public void treverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong: ");
            else
            {
                Console.WriteLine("\nData di dalam list adalah: ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noMhs + " " + currentNode.nama + "\n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

    }
  
    
}