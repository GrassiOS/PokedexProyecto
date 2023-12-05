//
//  PokeIDs00s.swift
//  Pokedex Test
//
//  Created by Martin on 30/07/23.
//

import Foundation

func zeros(id: Int) -> String{
    var stringChange = ""
    
    if id >= 10 {
        if id >= 100 {
            stringChange = "#" + String(id)
        }
        else
        {
            stringChange = "#0" + String(id)
        }
    }else
    {
        stringChange = "#00" + String(id)
    }
    
    return stringChange
}
