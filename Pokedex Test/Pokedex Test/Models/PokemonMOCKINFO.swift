//
//  Pokemon.swift
//  Pokedex Test
//
//  Created by Martin on 30/07/23.
//

import Foundation

struct PokemonMOCKINFO: Codable, Identifiable,Hashable {
    let id: Int
    let name: String
    let type: PokemonType
    let hp: Int
    let description: String
    let weakness: PokemonType
    let moves: [Move]
    let color: String
}
/*

extension PokemonMOCKINFO {
    static var MOCK_POKEMON: [PokemonMOCKINFO] = [
        .init(id: 1, name: "pikachu", type: PokemonType(id: 1,name: "electric", img: "electric"), hp: 160, description: "He is really cool sometimes", weakness: PokemonType(id: 1,name: "normal", img: "normal"), moves: [
            Move(id: 45, name: "growl", type: PokemonType(id: 1,name: "normal", img: "normal")),
            Move(id: 98, name: "quick attack", type: PokemonType(id: 1,name: "normal", img: "normal")),
            Move(id: 85, name: "thunderbolt", type: PokemonType(id: 1,name: "electric", img: "electric"))
        ],color: "yellow"),
        
        .init(id: 2, name: "squirtle", type: PokemonType(id: 1,name: "water", image: "water"), hp: 20, description: "He is really drowning sometimes", weakness: PokemonType(id: 1,name: "electric", image: "electric"), moves: [
            Move(id: 45, name: "growl", type: PokemonType(id: 1,name: "normal", image: "normal")),
            Move(id: 85, name: "thunderbolt", type: PokemonType(id: 1,name: "electric", image: "electric"))
        ],color: "blue"),
        
        .init(id: 3, name: "mewtwo", type: PokemonType(id: 1,name: "psychic", image: "psychic"), hp: 300, description: "He is really legendary sometimes", weakness: PokemonType(id: 1,name: "normal", image: "normal"), moves: [
            Move(id: 98, name: "quick attack", type: PokemonType(id: 1,name: "normal", image: "normal")),
            Move(id: 85, name: "thunderbolt", type: PokemonType(id: 1,name: "electric", image: "electric"))
        ],color: "purple")
    ]
}

*/
