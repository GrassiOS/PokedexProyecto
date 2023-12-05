

import Foundation

struct PokemonMove: Codable, Identifiable,Hashable {
    
    let id: Int
    let name: String
    let img: String
    
    
}


extension PokemonMove {
    static var MOCK_MOVES: [Move] = [
        .init(id: 1, name: "Quick Attack", type: PokemonType(id: 1, name: "normal", img: "normal"))
    ]
}
