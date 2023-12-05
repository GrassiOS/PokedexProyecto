//
//  PokemonAPI.swift
//  Pokedex Test
//
//  Created by Martin on 18/10/23.
//

import Foundation

struct Pokemon: Codable, Identifiable, Hashable {
    let id: Int
    let name: String
    let img: String
    let hp: Int
    let description: String
    let color: String
    let speed: Int
    let attack: Int
    let defense: Int
    let typeId: Int?
    let type: PokemonType?
    let weaknessTypeId: Int?
    let weaknessType: PokemonType?
    let pokemonMoves: [Move]?
}

class PokeAPI {
    let session: URLSession = {
        let sessionConfig = URLSessionConfiguration.default
        return URLSession(configuration: sessionConfig, delegate: SelfSignedCertificateDelegate(), delegateQueue: nil)
    }()
    
    func getPokemonList(completion: @escaping ([Pokemon]) -> ()) {
        guard let url = URL(string: "https://127.0.0.1:7172/api/Pokemon/all") else {
            return
        }
        
        print(url)
        Task {
            do {
                print("entered do")
                let (data, _) = try await session.data(from: url)
                print("let data")
                let decoder = JSONDecoder()
                print("let decoder")
                if let jsonString = String(data: data, encoding: .utf8) {
                    print("Received JSON data: Yes")
                }
                let pokemonList = try decoder.decode([Pokemon].self, from: data)
                print("let pokemonList")
                completion(pokemonList)
                print("completion")
            } catch {
                print("DEBUG: Error getting Pokémon list: \(error.localizedDescription)")
            }
        }
    }
}



struct PokemonReference: Codable {
        let ref: String
    }

extension Pokemon {
    static var MOCK_POKEMON : [Pokemon] = [
        .init(id: 1, name: "bulbasur", img: "https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png", hp: 40, description: "He is really cool sometimes", color: "green", speed: 50, attack: 20, defense: 50, typeId: 2, type: PokemonType.MOCK_TYPES[1], weaknessTypeId: 1, weaknessType: PokemonType.MOCK_TYPES[1], pokemonMoves: nil),
        
        .init(id: 2, name: "pikachu", img: "https://assets.pokemon.com/assets/cms2/img/pokedex/full/025.png", hp: 40, description: "He is really cool sometimes", color: "yellow", speed: 50, attack: 20, defense: 50, typeId: 2, type: PokemonType.MOCK_TYPES[1], weaknessTypeId: 1, weaknessType: PokemonType.MOCK_TYPES[1], pokemonMoves: nil),
        
            .init(id: 3, name: "mr. mime", img: "https://assets.pokemon.com/assets/cms2/img/pokedex/full/122.png", hp: 40, description: "He is really dumb sometimes", color: "pink", speed: 50, attack: 20, defense: 50, typeId: 2, type: PokemonType.MOCK_TYPES[1], weaknessTypeId: 1, weaknessType: PokemonType.MOCK_TYPES[1], pokemonMoves: [Move.MOCK_MOVE[0],Move.MOCK_MOVE[1],Move.MOCK_MOVE[2]])
        
        
        ]
}
