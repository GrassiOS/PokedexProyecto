//
//  ActivePokemon.swift
//  Pokedex Test
//
//  Created by Martin on 16/11/23.
//

import SwiftUI

struct ActivePokemon: View {
    let poke: Pokemon
    var body: some View {
        ZStack {
            Circle()
                .foregroundColor(Color.fromString(poke.color))
                .frame(width: 171, height: 171)
                .blur(radius: 30)
            
            AsyncImage(url: URL(string: poke.img ?? "")) { phase in
                switch phase {
                case .empty:
                    ProgressView()
                case .success(let image):
                    image
                        .resizable()
                        .scaledToFill()
                        .frame(width: 150, height: 150)
                        .shadow(color: .gray.opacity(0.2), radius: 12)
                case .failure:
                    Image("mr mime") // You can provide a placeholder image here
                        .resizable()
                        .scaledToFill()
                        .frame(width: 150, height: 150)
                @unknown default:
                    Image("mr mime") // You can provide a placeholder image here
                        .resizable()
                        .scaledToFill()
                        .frame(width: 150, height: 150)
                }
            }
            
        }
    }
}

#Preview {
    ActivePokemon(poke: Pokemon.MOCK_POKEMON[1])
}
