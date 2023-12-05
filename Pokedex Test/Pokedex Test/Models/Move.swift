//
//  Move.swift
//  Pokedex Test
//
//  Created by Martin on 30/07/23.
//

import Foundation

struct Move: Codable, Identifiable,Hashable {
    let id: Int
    let name: String
    let type: PokemonType
    var power: Int?
    var accuracy: Int?
}

extension Move {
    static var MOCK_MOVE: [Move] = [
        .init(id: 1, name: "Quick Attack", type: PokemonType(id: 1,name: "normal", img: "normal")),
        .init(id: 2, name: "Rapid Attack", type: PokemonType(id: 1, name: "grass", img: "grass")),
        .init(id: 3, name: "Poor Attack", type: PokemonType(id: 1, name: "fire", img: "fire"))
    ]
}

//.init(id: 1, name: "Quick Attack", type: PokeType(name: "normal", image: "normal"))
