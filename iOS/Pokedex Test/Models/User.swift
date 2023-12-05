//
//  User.swift
//  Pokedex Test
//
//  Created by Martin on 02/11/23.
//

import Foundation

struct User : Codable, Identifiable, Hashable {
    let id: Int
    var username: String
    let email: String
    let password: String
    var img: String?
    var Ws: Int?
    var Ls: Int?
    
    var pokemonCollection: [Pokemon]
    
    
    mutating func addPokemon(poke: Pokemon) {
        if !pokemonCollection.contains(where: { $0.id == poke.id }) {
            pokemonCollection.append(poke)
        }
    }
    
    mutating func removePokemon(poke: Pokemon) {
        pokemonCollection.removeAll { $0.id == poke.id }
    }
    
    // Check if the user has a specific Pokemon in their collection
    func hasPokemon(poke: Pokemon) -> Bool {
        return pokemonCollection.contains { $0.id == poke.id }
    }
}

extension User {
    static var MOCK_USERS: [User] = [
        /*
        .init(id: 1, username: "GrassyTest", email: "grassydarkz@gmail.com", password: "123123"),
        .init(id: 2, username: "Test", email: "Test@gmail.com", password: "321321", img: "mr mime", Ws: 0, Ls: 0, pokemonCollection: nil),
         */
        
        .init(id: 3, username: "GrassyOG", email: "Grassy@gmail.com", password: "321321", img: "electric", Ws: 0, Ls: 0, pokemonCollection: [
            Pokemon.MOCK_POKEMON[0],Pokemon.MOCK_POKEMON[2],Pokemon.MOCK_POKEMON[1],Pokemon.MOCK_POKEMON[2],Pokemon.MOCK_POKEMON[1],Pokemon.MOCK_POKEMON[2]
            ]),
        
        .init(id: 4, username: "Opponent", email: "Opp@gmail.com", password: "321321", img: "electric", Ws: 0, Ls: 0, pokemonCollection: [
            Pokemon.MOCK_POKEMON[1],Pokemon.MOCK_POKEMON[2],Pokemon.MOCK_POKEMON[1],Pokemon.MOCK_POKEMON[2],Pokemon.MOCK_POKEMON[1],Pokemon.MOCK_POKEMON[2]
            ])
        
    ]
}

