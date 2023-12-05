//
//  Type.swift
//  Pokedex Test
//
//  Created by Martin on 30/07/23.
//

import Foundation

struct PokemonType: Identifiable, Codable, Hashable {
    let id: Int
    let name: String
    let img: String
}

extension PokemonType {
    static var MOCK_TYPES: [PokemonType] = [
        .init(id: 1, name: "normal", img: "normal"),
        .init(id: 2, name: "grass", img: "grass"),
        .init(id: 3, name: "electric", img: "electric")

    ]
}

class PokeAPI_Types {
    
    let session: URLSession = {
        let sessionConfig = URLSessionConfiguration.default
        return URLSession(configuration: sessionConfig, delegate: SelfSignedCertificateDelegate(), delegateQueue: nil)
    }()
    
    func getPokemonTypeList(completion: @escaping ([PokemonType]) -> ()) {
        guard let url = URL(string: "https://127.0.0.1:7172/api/Pokemon/all") else {
            return
        }
        
        Task {
            do {
                let (data, _) = try await session.data(from: url)
                let decoder = JSONDecoder()
                let pokemonTypeList = try decoder.decode([PokemonType].self, from: data)
                completion(pokemonTypeList)
            } catch {
                print("DEBUG: Error getting Pokémon list: \(error.localizedDescription)")
            }
        }
    }
}
